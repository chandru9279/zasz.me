using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using zasz.me.Areas.Shared.Controllers.Utils;
using zasz.me.Areas.Shared.Models;
using zasz.me.Integration.MVC;

namespace zasz.me.Areas.Shared.Controllers
{
    public abstract class PostController : BaseController
    {
        private const string ManageViewPath = "~/Areas/Shared/Views/Post/Manage.cshtml";
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

        public ActionResult Create()
        {
            return View(ManageViewPath, new Post());
        }

        public ActionResult Edit(string Id)
        {
            return View(ManageViewPath, _Posts.Get(Id));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Manage(string PostContent, string Title, string Tags, string ChosenSite, string Slug)
        {
            bool New = string.IsNullOrEmpty(Slug);

            Post Entry = New ? new Post() : _Posts.Get(Slug);

            Entry.Title = Title;
            Entry.Content = PostContent;
            Entry.Site = Site.WithName(ChosenSite);
            Entry.Tags =
                Tags.Split(Constants.Shredders, StringSplitOptions.RemoveEmptyEntries).Select(
                    It => _Tags.Get(It) ?? new Tag(It)).
                    ToList();
            if (New) Entry.Slug = GetSlug(Title);
            if (New) Entry.Timestamp = DateTime.Now;

            if (New)
                if (ModelState.IsValid)
                    _Posts.Save(Entry);
                else
                    return View(ManageViewPath, Entry);

            _Posts.Commit();
            return RedirectToAction("Post", new {Id = Slug});
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