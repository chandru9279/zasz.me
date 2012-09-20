using System;
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
        public ActionResult Delete(string Id)
        {
            /* Todo : Need to figure out a way to delete without fetching */
            var post = Posts.Get(Id);
            post.Tags.Clear();
            Posts.Delete(post);
            Posts.Commit();
            return RedirectToAction("List", "Blog");
        }
    }
}