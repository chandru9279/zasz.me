using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using zasz.me.Controllers.Utils;
using zasz.me.Integration.MVC;
using zasz.me.Models;
using zasz.me.ViewModels;

namespace zasz.me.Controllers
{
    public abstract class PostController : BaseController
    {
        private const string MANAGE_VIEW_PATH = "~/Views/Post/Manage.cshtml";
        protected readonly IPostRepository _Posts;
        protected readonly ITagRepository _Tags;

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
                                NumberOfPages = (int) Math.Ceiling(_Posts.Count(ProOrRest)/(double) MaxPostsPerPage),
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
                                        WhatIsListed = "Posts tagged with <em>" + Tag + "</em>"
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
            var Post = _Posts.Get(Id);
            Post.Tags.Clear();
            _Posts.Delete(Post);
            _Posts.Commit();
            return Redirect("/Blog/List");
        }

        [HttpPost]
        [Authorize]
        [Secure]
        [ValidateInput(false)]
        public ActionResult Manage(string PostContent, string Title, string Tags, string ChosenSite, string Slug)
        {
            var New = string.IsNullOrEmpty(Slug);

            var Entry = New ? new Post() : _Posts.Get(Slug);

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
            return Redirect("/Blog/Post/" + Entry.Slug);
        }

        public static string GetSlug(string Title)
        {
            var DecodedTitle = HttpUtility.HtmlDecode(Title).ToLower();
            var NearlySlug = Constants.GoWords().Aggregate
                (
                    DecodedTitle,
                    (Current, Pair) => Current.Replace(Pair.Key, " " + Pair.Value + " ")
                );
            var Sluglets =
                (from object Match in Regex.Matches(NearlySlug, @"[a-zA-Z0-9.-]+") select Match.ToString()).ToList();
            return string.Join("-", Sluglets);
        }
    }
}