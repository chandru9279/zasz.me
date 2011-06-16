using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Elmah;
using Microsoft.Practices.Unity;
using zasz.me.Areas.Shared.Controllers.Utils;
using zasz.me.Areas.Shared.Models;
using zasz.me.Integration.MVC;
using zasz.me.Services;

namespace zasz.me.Areas.Shared.Controllers
{
    public abstract class PostController : BaseController
    {
        private const string MANAGE_VIEW_PATH = "~/Areas/Shared/Views/Post/Manage.cshtml";
        protected readonly IPostRepository _Posts;
        private readonly ITagRepository _Tags;

        protected PostController(IPostRepository Posts, ITagRepository Tags)
        {
            _Posts = Posts;
            _Tags = Tags;
        }

        [Dependency("MaxPostsPerPage")]
        public int MaxPostsPerPage { get; set; }

        [Dependency("DescriptionLength")]
        public int DescriptionLength { get; set; }

        protected ActionResult List(Site ProOrRest, int PageNumber)
        {
            return View(new PostListModel
                            {
                                Posts = _Posts.Page(PageNumber - 1, MaxPostsPerPage, ProOrRest),
                                NumberOfPages = _Posts.Count(ProOrRest)/MaxPostsPerPage,
                                DescriptionLength = DescriptionLength,
                                WhatIsListed = "Recent Posts.."
                            });
        }

        protected ActionResult Tag(Site ProOrRest, string Tag, int PageNumber)
        {
            return View("List", new PostListModel
                                    {
                                        Posts = _Tags.PagePosts(Tag, PageNumber - 1, MaxPostsPerPage, ProOrRest),
                                        NumberOfPages = _Tags.CountPosts(Tag, ProOrRest)/MaxPostsPerPage,
                                        DescriptionLength = DescriptionLength,
                                        WhatIsListed = "Posts tagged with \"" + Tag + "\""
                                    });
        }

        protected ActionResult ArchiveControl(Site ProOrRest)
        {
            return PartialView(_Posts.PostedMonthsYearGrouped(ProOrRest));
        }

        protected ActionResult Archive(Site ProOrRest, int Year, int Month)
        {
            return View("List", new PostListModel
                                    {
                                        Posts = _Posts.Archive(Year, Month, ProOrRest),
                                        NumberOfPages = 1,
                                        DescriptionLength = DescriptionLength,
                                        WhatIsListed =
                                            string.Format("Archived for {0:MMMM, yyyy}", new DateTime(Year, Month, 1))
                                    });
        }

        [Authorize]
        [Secure]
        public ActionResult Create()
        {
            return View(MANAGE_VIEW_PATH, new Post());
        }

        [Authorize]
        [Secure]
        public ActionResult Edit(string Id)
        {
            return View(MANAGE_VIEW_PATH, _Posts.Get(Id));
        }

        [Authorize]
        public ActionResult Delete(string Id)
        {
            /* Todo : Need to figure out a way to delete without fetching */
            _Posts.Delete(_Posts.Get(Id));
            _Posts.Commit();
            return Redirect("/Writings/List");
        }

        [HttpPost]
        [Authorize]
        [Secure]
        [ValidateInput(false)]
        public ActionResult Manage(string PostContent, string Title, string Tags, string ChosenSite, string Slug)
        {
            bool New = string.IsNullOrEmpty(Slug);

            Post Entry = New ? new Post() : _Posts.Get(Slug);

            Entry.Title = Title;
            Entry.Content = PostContent;
            Entry.Site = Site.With(ChosenSite);
            if (Entry.Tags != null) Entry.Tags.Clear();
            Entry.Tags =
                Tags.Split(Constants.Shredders, StringSplitOptions.RemoveEmptyEntries).Select(
                    It => _Tags.Get(It) ?? _Tags.Save(new Tag(It))).
                    ToList();
            if (New) Entry.Slug = GetSlug(Title);
            if (New) Entry.Timestamp = DateTime.Now;

            if (New)
                if (ModelState.IsValid)
                    _Posts.Save(Entry);
                else
                    return View(MANAGE_VIEW_PATH, Entry);

            _Posts.Commit();
            return Redirect("/Writings/Post/" + Entry.Slug);
        }

        public static string GetSlug(string Title)
        {
            string DecodedTitle = HttpUtility.HtmlDecode(Title).ToLower();
            string NearlySlug = Constants.GoWords().Aggregate
                (
                    DecodedTitle,
                    (Current, Pair) => Current.Replace(Pair.Key, " " + Pair.Value + " ")
                );
            List<string> Sluglets =
                (from object Match in Regex.Matches(NearlySlug, @"[a-zA-Z0-9.-]+") select Match.ToString()).ToList();
            return string.Join("-", Sluglets);
        }

        protected ActionResult TagCloud(Site ProOrRest, int Width, int Height)
        {
            Dictionary<string, int> WeightedTags = _Tags.WeightedList(ProOrRest);
            if (WeightedTags.Count == 0) return View();
            var FontsService = new FontsService();
            FontsService.LoadFonts(Request.MapPath(@"~\Content\Shared\Fonts"));
            var TagCloudService = new TagCloudService(WeightedTags, Width, Height)
                                      {
                                          MaximumFontSize = 52f,
                                          MinimumFontSize = 18f,
                                          Margin = 10,
                                          SelectedFont = FontsService.AvailableFonts["Kenyan Coffee"],
                                          DisplayChoice =
                                              DisplayStrategy.Get(TagDisplayStrategy.RandomHorizontalOrVertical),
                                          ColorChoice =
                                              ColorStrategy.Get(Theme.LightBgDarkFg, Style.Varied,
                                                                Color.FromArgb(0, Color.White), Color.Red),
                                          VerticalTextRight = true,
                                          Crop = true
                                      };

            Dictionary<string, RectangleF> Borders;
            Bitmap Bitmap = TagCloudService.Construct(out Borders);
            if (TagCloudService.WordsSkipped.Count() > 0)
            {
                string Msg = "Need a bigger Image - these words skipped : " +
                             string.Join("; ", TagCloudService.WordsSkipped.Select(It => It.Key));
                Console.WriteLine(Msg);
                ErrorSignal.FromCurrentContext().Raise(new Exception(Msg));
            }
            Bitmap.Save(Request.MapPath(@"~\Content\Pro\Images\Cloud.png"), ImageFormat.Png);
            return View(Borders);
        }

        #region Nested type: PostListModel

        public class PostListModel
        {
            public List<Post> Posts { get; set; }
            public int NumberOfPages { get; set; }
            public int DescriptionLength { get; set; }
            public string WhatIsListed { get; set; }
        }

        #endregion
    }
}