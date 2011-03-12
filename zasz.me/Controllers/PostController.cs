using System;
using System.Collections.Generic;
using System.Web.Mvc;
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
        public ActionResult Create(string PostContent, string Title, string Tags, Area Area, string Slug)
        {
            try
            {
                Post Entry = new Post();
                Entry.Title = Title;
                Entry.Content = PostContent;
                Entry.Tags = new List<string>(Tags.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries));
                Entry.Area = Area;
                Entry.Slug = String.IsNullOrEmpty(Slug) ? GetSlug(Title) : Slug;
                Entry.Permalink = "http://" + Models.Areas.Url(Area);
                Posts.Save(Entry);
                return View("Post", Entry);
            }
            catch
            {
                return View();
            }
        }

        private string GetSlug(string Title)
        {
            throw new NotImplementedException();
        }
    }
}