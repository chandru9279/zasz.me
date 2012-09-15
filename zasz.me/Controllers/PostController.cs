using System;
using System.Linq;
using System.Security.Policy;
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
        private const string ManageViewPath = "~/Views/Post/Manage.cshtml";
        protected readonly IPostRepository Posts;
        protected readonly ITagRepository Tags;

        protected PostController(IPostRepository posts, ITagRepository tags)
        {
            Posts = posts;
            Tags = tags;
        }

        [Dependency("MaxPostsPerPage")]
        public int MaxPostsPerPage { get; set; }

        [Dependency("DescriptionLength")]
        public int DescriptionLength { get; set; }

        public ActionResult Post([Bind(Prefix = "Id")] string slug)
        {
            return View(Posts.Get(slug));
        }

        [DefaultAction]
        public ActionResult List([Bind(Prefix = "Id")] int pageNumber = 1)
        {
            return View(new PostListViewModel
                            {
                                Posts = Posts.Page(pageNumber - 1, MaxPostsPerPage),
                                NumberOfPages = (int) Math.Ceiling(Posts.Count()/(double) MaxPostsPerPage),
                                DescriptionLength = DescriptionLength,
                                WhatIsListed = "Recent Posts.."
                            });
        }

        public ActionResult Tag(string tag, int page = 1)
        {
            return View("List", new PostListViewModel
                                    {
                                        Posts = Tags.PagePosts(tag, page - 1, MaxPostsPerPage),
                                        NumberOfPages = Tags.CountPosts(tag)/MaxPostsPerPage,
                                        DescriptionLength = DescriptionLength,
                                        WhatIsListed = "Posts tagged with <em>" + tag + "</em>"
                                    });
        }


        public ActionResult Archive(int year, string month)
        {
            return View("List", new PostListViewModel
                                    {
                                        Posts = Posts.Archive(year, Constants.Months[month]),
                                        NumberOfPages = 1,
                                        DescriptionLength = DescriptionLength,
                                        WhatIsListed =
                                            string.Format("Archived for {0:MMMM, yyyy}",
                                                          new DateTime(year, Constants.Months[month], 1))
                                    });
        }

        [Authorize]
        [Secure]
        public ActionResult Create()
        {
            return View(ManageViewPath, new Post());
        }

        [Authorize]
        [Secure]
        public ActionResult Edit(string id)
        {
            return View(ManageViewPath, Posts.Get(id));
        }

        [Authorize]
        public ActionResult Delete(string Id)
        {
            /* Todo : Need to figure out a way to delete without fetching */
            var post = Posts.Get(Id);
            post.Tags.Clear();
            Posts.Delete(post);
            Posts.Commit();
            return RedirectToAction("List", "Blog");
        }

        [HttpPost]
        [Authorize]
        [Secure]
        [ValidateInput(false)]
        public ActionResult Manage(string postContent, string title, string tags, string slug)
        {
            var isNew = string.IsNullOrEmpty(slug);

            var entry = isNew ? new Post() : Posts.Get(slug);

            entry.Title = title;
            entry.Content = postContent;
            if (entry.Tags != null) entry.Tags.Clear();
            entry.Tags =
                tags.Split(Constants.Shredders, StringSplitOptions.RemoveEmptyEntries).Select(
                    x => Tags.Get(x) ?? Tags.Save(new Tag(x))).
                    ToList();
            if (isNew) entry.Slug = GetSlug(title);
            if (isNew) entry.Timestamp = DateTime.Now;

            if (isNew)
                if (ModelState.IsValid)
                    Posts.Save(entry);
                else
                    return View(ManageViewPath, entry);

            Posts.Commit();
            return Redirect("/Blog/Post/" + entry.Slug);
        }

        public static string GetSlug(string title)
        {
            var decodedTitle = HttpUtility.HtmlDecode(title).ToLower();
            var nearlySlug = Constants.GoWords().Aggregate
                (
                    decodedTitle,
                    (current, pair) => current.Replace(pair.Key, " " + pair.Value + " ")
                );
            var sluglets = (from object match in Regex.Matches(nearlySlug, @"[a-zA-Z0-9.-]+") select match.ToString());
            return string.Join("-", sluglets);
        }
    }
}