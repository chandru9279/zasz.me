using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using zasz.me.Areas.Shared.Controllers.Utils;
using zasz.me.Areas.Shared.Models;

namespace zasz.me.Areas.Shared.Controllers
{
    public abstract class PostController : Controller
    {
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
                                NumberOfPages = _Posts.Count(ProOrRest) / MaxPostsPerPage,
                                DescriptionLength = DescriptionLength,
                                WhatIsListed = "Recent Posts.."
                            });
        }

        protected ActionResult Tag(Site ProOrRest, string Tag, int PageNumber)
        {
            return View("List", new PostListModel
                                    {
                                        Posts = _Tags.PagePosts(Tag, PageNumber - 1, MaxPostsPerPage, ProOrRest),
                                        NumberOfPages = _Tags.CountPosts(Tag, ProOrRest) / MaxPostsPerPage,
                                        DescriptionLength = DescriptionLength,
                                        WhatIsListed = "Posts tagged with \""  + Tag + "\""
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
                                        WhatIsListed = string.Format("Archived for {0:MMMM, yyyy}", new DateTime(Year, Month, 1))
                                    });
        }

        protected ActionResult Create()
        {
            ViewBag.EditorName = "PostContent";
            return View();
        }

        [HttpPost]
        protected ActionResult Create(string PostContent, string Title, string Tags, string ChosenSite, string Slug)
        {
            try
            {
                var Entry = new Post
                                {
                                    Title = Title,
                                    Content = PostContent,
                                    Site = Site.WithName(ChosenSite),
                                    Tags =
                                        Tags.Split(Constants.Shredders, StringSplitOptions.RemoveEmptyEntries).ToList().
                                        Collect(It => new Tag(It)),
                                    Slug = String.IsNullOrEmpty(Slug) ? GetSlug(Title) : Slug,
                                    Timestamp = DateTime.Now
                                };
                _Posts.Save(Entry);
                return View("Post", Entry);
            }
            catch
            {
                return View();
            }
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