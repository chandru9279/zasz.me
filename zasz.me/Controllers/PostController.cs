using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using zasz.me.Controllers.Utils;
using zasz.me.Models;

namespace zasz.me.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository Posts;

        public PostController(IPostRepository Posts)
        {
            this.Posts = Posts;
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
                                    Tags =
                                        new List<string>(Tags.Split(Constants.Shredders,
                                                                    StringSplitOptions.RemoveEmptyEntries)),
                                    Site = Site.WithName(ChosenSite),
                                    Slug = String.IsNullOrEmpty(Slug) ? GetSlug(Title) : Slug,
                                    Timestamp = DateTime.Now
                                };
                Entry.Permalink = string.Format("http://{0}/{1}/post/{2}", Entry.Site.Host, Entry.Site.Name, Entry.Slug);
                Posts.Save(Entry);
                return View("Post", Entry);
            }
            catch
            {
                return View();
            }
        }

        public static string GetSlug(string Title)
        {
            Title = HttpUtility.HtmlDecode(Title).Replace("&", "and");
            return string.Join("-", Regex.Matches(@"[a-zA-Z0-9.-]+", Title));
        }
    }
}