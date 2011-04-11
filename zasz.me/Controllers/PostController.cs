using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using zasz.me.Controllers.Utils;
using zasz.me.Models;

namespace zasz.me.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository _Posts;
        private int _MaxPostsPerPage;

        public PostController(IPostRepository Posts)
        {
            _Posts = Posts;
        }

        [Dependency("MaxPostsPerPage")]
        public int MaxPostsPerPage
        {
            get { return _MaxPostsPerPage; }
            set { _MaxPostsPerPage = value; }
        }

        public ActionResult List(int PageNumber = 0)
        {
            return View(new PostListModel(
                            _Posts.Page(PageNumber, _MaxPostsPerPage),
                            (int) (_Posts.Count() / _MaxPostsPerPage)
                            ));
        }

        public ActionResult Create()
        {
            ViewBag.EditorName = "PostContent";
            return View();
        }

        [HttpPost]
        public ActionResult Create(string PostContent, string Title, string Tags, string ChosenSite, string Slug)
        {
            try
            {
                var Entry = new Post
                                {
                                    Title = Title,
                                    Content = PostContent,
                                    Tags = new List<string>(Tags.Split(Constants.Shredders,
                                                                       StringSplitOptions.RemoveEmptyEntries)),
                                    Site = Site.WithName(ChosenSite),
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
            var Sluglets = (from object Match in Regex.Matches(NearlySlug, @"[a-zA-Z0-9.-]+") select Match.ToString()).ToList();
            return string.Join("-", Sluglets);
        }

        #region Nested type: PostListModel

        public class PostListModel
        {
            public PostListModel(List<Post> Posts, int NumberOfPages)
            {
                this.Posts = Posts;
                this.NumberOfPages = NumberOfPages;
            }

            public List<Post> Posts { get; set; }

            public int NumberOfPages { get; set; }
        }

        #endregion
    }
}