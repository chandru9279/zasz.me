using System;
using System.Web.Mvc;

using zasz.me.Controllers.Utils;
using zasz.me.Integration.MVC;
using zasz.me.Models;
using zasz.me.Services.Concrete.Config;
using zasz.me.Services.Contracts;
using zasz.me.ViewModels;

namespace zasz.me.Controllers
{
    [Sidebar]
    public abstract class PostController : BaseController
    {
        protected readonly IPostRepository Posts;
        protected readonly ITagRepository Tags;
        protected readonly BlogConfig config;

        protected PostController(IPostRepository posts, ITagRepository tags, IConfigurationService configService)
        {
            Posts = posts;
            Tags = tags;
            config = configService.Blog;
        }

        public ActionResult Post([Bind(Prefix = "Id")] string slug)
        {
            return View(Posts.Get(slug));
        }

        [DefaultAction]
        public ActionResult List([Bind(Prefix = "Id")] int pageNumber = 1)
        {
            return View(new PostListViewModel
                            {
                                Set = Posts.Page(pageNumber - 1, config.MaxPostsPerPage),
                                NumberOfPages = (int)Math.Ceiling(Posts.Count() / (double)config.MaxPostsPerPage),
                                DescriptionLength = config.DescriptionLength,
                                WhatIsListed = "Recent Posts.."
                            });
        }

        public ActionResult Tag(string tag, int page = 1)
        {
            return View("List", new PostListViewModel
                                    {
                                        Set = Tags.PagePosts(tag, page - 1, config.MaxPostsPerPage),
                                        NumberOfPages = Tags.CountPosts(tag) / config.MaxPostsPerPage,
                                        DescriptionLength = config.DescriptionLength,
                                        WhatIsListed = "Posts tagged with <em>" + tag + "</em>"
                                    });
        }


        public ActionResult Archive(int year, string month)
        {
            return View("List", new PostListViewModel
                                    {
                                        Set = Posts.Archive(year, Constants.Months[month]),
                                        NumberOfPages = 1,
                                        DescriptionLength = config.DescriptionLength,
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