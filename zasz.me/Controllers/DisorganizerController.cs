using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Elmah;
using zasz.me.Integration.MVC;
using zasz.me.Services.TagCloud;
using zasz.me.ViewModels;

namespace zasz.me.Controllers
{
    public class DisorganizerController : BaseController
    {
        [DefaultAction]
        public ActionResult Tinker()
        {
            var tinkerModel = new TinkerModel();
            using (var service = new FontsService())
            {
                service.LoadFonts(Request.MapPath("~/Content/Fonts"));
                tinkerModel.Fonts.AddRange(service.AvailableFonts.Keys.ToArray());
            }
            tinkerModel.Strategies.AddRange(Enum.GetNames(typeof (TagDisplayStrategy)));
            tinkerModel.Themes.AddRange(Enum.GetNames(typeof (Theme)));
            tinkerModel.Styles.AddRange(Enum.GetNames(typeof (Style)));
            return View(tinkerModel);
        }

        public ActionResult Links()
        {
            var model = new LinkViewModel();
            try
            {
                model.Borders = (Dictionary<string, RectangleF>) TempData["TinkerBorders"];
                model.GenerateTime = (float) TempData["GenerateTime"];
                model.Skipped = (string) TempData["Skipped"];
            }
            catch
            {
                model = null;
            }
            return View(model);
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult Cloud(TinkerModel Model)
        {
            Model.Strategies.AddRange(Enum.GetNames(typeof (TagDisplayStrategy)));
            Model.Themes.AddRange(Enum.GetNames(typeof (Theme)));
            Model.Styles.AddRange(Enum.GetNames(typeof (Style)));
            Dictionary<string, int> tags;
            try
            {
                tags = Model.Dictionary();
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                return File("~/Content/Images/404.png", "image/png");
            }
            var tagCloudService = new TagCloudService(tags, int.Parse(Model.Width), int.Parse(Model.Height))
                                      {
                                          MaximumFontSize = float.Parse(Model.MaxFontSize),
                                          MinimumFontSize = float.Parse(Model.MinFontSize),
                                      };

            if (!String.IsNullOrEmpty(Model.Angle)) tagCloudService.Angle = int.Parse(Model.Angle);
            if (!String.IsNullOrEmpty(Model.Margin)) tagCloudService.Margin = int.Parse(Model.Margin);

            using (var Service = new FontsService())
            {
                Service.LoadFonts(Request.MapPath("~/Content/Fonts"));
                Model.Fonts.AddRange(Service.AvailableFonts.Keys.ToArray());
                if (!String.IsNullOrEmpty(Model.SelectedFont))
                    tagCloudService.SelectedFont = Service.AvailableFonts[Model.SelectedFont];
            }

            if (!String.IsNullOrEmpty(Model.SelectedStrategy))
                tagCloudService.DisplayChoice = DisplayStrategy.Get(Model.SelectedStrategy.Enumize<TagDisplayStrategy>());

            var BgfgScheme = !String.IsNullOrEmpty(Model.SelectedTheme)
                                 ? Model.SelectedTheme.Enumize<Theme>()
                                 : Theme.LightBgDarkFg;
            var FgScheme = !String.IsNullOrEmpty(Model.SelectedStyle)
                               ? Model.SelectedStyle.Enumize<Style>()
                               : Style.Varied;

            tagCloudService.ColorChoice = ColorStrategy.Get(BgfgScheme, FgScheme,
                                                            Model.GetBackgroundColor(), Model.GetForegroundColor());

            tagCloudService.VerticalTextRight = Model.VerticalTextRight;
            tagCloudService.ShowWordBoundaries = Model.ShowBoundaries;
            tagCloudService.Crop = Model.Crop;
            tagCloudService.SpiralRoom = Model.SpiralRoom;

            var watch = new Stopwatch();
            watch.Start();
            Dictionary<string, RectangleF> Borders;
            var Bitmap = tagCloudService.Construct(out Borders);
            watch.Stop();

            TempData["TinkerBorders"] = Borders;
            TempData["GenerateTime"] = watch.ElapsedMilliseconds/(float) 1000;
            TempData["Skipped"] = string.Join("; ", tagCloudService.WordsSkipped.Select(x => x.Key));

            var stream = new MemoryStream();
            Bitmap.Save(stream, ImageFormat.Png);
            return File(stream.ToArray(), "image/png");
        }
    }
}