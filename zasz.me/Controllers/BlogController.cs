using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Elmah;
using zasz.me.Models;
using zasz.me.Services.Contracts;
using zasz.me.Services.TagCloud;

namespace zasz.me.Controllers
{
    public class BlogController : PostController
    {
        public BlogController(IPostRepository posts, ITagRepository tags, IConfigurationService configService)
            : base(posts, tags, configService)
        {
        }

        /* Use Handy.InvalidateOutputCache() when Creating a Post to manually expire this cache*/

        [OutputCache(Duration = 3600)]
        [ChildActionOnly]
        public ActionResult ArchiveControl()
        {
            return PartialView(Posts.PostedMonthsYearGrouped());
        }

        public FileContentResult TagCloud()
        {
            const int width = 214;
            const int height = 500;
            var weightedTags = Tags.WeightedList();
            FontFamily font;
            using (var service = new FontsService())
            {
                service.LoadFonts(Request.MapPath(@"~\Content\Fonts"));
                font = service.AvailableFonts["Kenyan Coffee"];
            }
            var tagCloudService = new TagCloudService(weightedTags, width, height)
                                      {
                                          MaximumFontSize = 52f,
                                          MinimumFontSize = 18f,
                                          Margin = 10,
                                          SelectedFont = font,
                                          DisplayChoice =
                                              DisplayStrategy.Get(TagDisplayStrategy.MoreHorizontalThanVertical),
                                          ColorChoice =
                                              ColorStrategy.Get(Theme.LightBgDarkFg, Style.Grayscale,
                                                                Color.FromArgb(0, Color.White), Color.Black),
                                          VerticalTextRight = true,
                                          Crop = true
                                      };

            Dictionary<string, RectangleF> borders;
            var bitmap = tagCloudService.Construct(out borders);
            if (tagCloudService.WordsSkipped.Any())
            {
                var msg = "Need a bigger Image - these words skipped : " +
                          string.Join("; ", tagCloudService.WordsSkipped.Select(x => x.Key));
                ErrorSignal.FromCurrentContext().Raise(new Exception(msg));
            }
            TempData["TagCloudBorders"] = borders;
            var stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Png);
            return File(stream.ToArray(), "image/png");
        }

        public ViewResult TagCloudLinks()
        {
            return View(TempData["TagCloudBorders"]);
        }
    }
}