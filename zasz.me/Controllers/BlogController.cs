using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Elmah;
using zasz.me.Controllers.Utils;
using zasz.me.Integration.MVC;
using zasz.me.Models;
using zasz.me.Services.TagCloud;

namespace zasz.me.Controllers
{
    public class BlogController : PostController
    {
        protected readonly Site _Site = Site.Pro;

        public BlogController(IPostRepository Posts, ITagRepository Tags) : base(Posts, Tags)
        {
        }

        [DefaultAction]
        public ActionResult List(int Id = 1)
        {
            return List(_Site, Id);
        }

        public ActionResult Post([Bind(Prefix = "Id")] string Slug)
        {
            return View(_Posts.Get(Slug));
        }

        public ActionResult Tag(string TagName, int PageNumber = 1)
        {
            return Tag(_Site, TagName, PageNumber);
        }

        /* Use Handy.InvalidateOutputCache() when Creating a Post to manually expire this cache*/

        [OutputCache(Duration = 3600)]
        [ChildActionOnly]
        public ActionResult ArchiveControl()
        {
            return ArchiveControl(_Site);
        }

        public ActionResult Archive(int Year, string Month)
        {
            return Archive(_Site, Year, Constants.Months[Month]);
        }

        public FileContentResult TagCloud()
        {
            int Width = 214, Height = 500;
            var WeightedTags = _Tags.WeightedList(_Site);
            FontFamily TheFont;
            using (var FontsService = new FontsService())
            {
                FontsService.LoadFonts(Request.MapPath(@"~\Content\Fonts"));
                TheFont = FontsService.AvailableFonts["Kenyan Coffee"];
            }
            var TagCloudService = new TagCloudService(WeightedTags, Width, Height)
                                      {
                                          MaximumFontSize = 52f,
                                          MinimumFontSize = 18f,
                                          Margin = 10,
                                          SelectedFont = TheFont,
                                          DisplayChoice =
                                              DisplayStrategy.Get(TagDisplayStrategy.RandomHorizontalOrVertical),
                                          ColorChoice =
                                              ColorStrategy.Get(Theme.LightBgDarkFg, Style.Varied,
                                                                Color.FromArgb(0, Color.White), Color.Red),
                                          VerticalTextRight = true,
                                          Crop = true
                                      };

            Dictionary<string, RectangleF> Borders;
            var Bitmap = TagCloudService.Construct(out Borders);
            if (TagCloudService.WordsSkipped.Any())
            {
                var Msg = "Need a bigger Image - these words skipped : " +
                          string.Join("; ", TagCloudService.WordsSkipped.Select(x => x.Key));
                ErrorSignal.FromCurrentContext().Raise(new Exception(Msg));
            }
            TempData["TagCloudBorders"] = Borders;
            var stream = new MemoryStream();
            Bitmap.Save(stream, ImageFormat.Png);
            return File(stream.ToArray(), "image/png");
        }

        public ViewResult TagCloudLinks()
        {
            return View(TempData["TagCloudBorders"]);
        }
    }
}