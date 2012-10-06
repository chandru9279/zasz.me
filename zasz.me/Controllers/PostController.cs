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
        protected readonly BlogConfig Config;

        protected PostController(IPostRepository posts, ITagRepository tags, IConfigurationService configService)
        {
            Posts = posts;
            Tags = tags;
            Config = configService.Blog;
        }

        public ActionResult Post([Bind(Prefix = "id")] string slug)
        {
            return View(Posts.Get(slug));
        }

        [DefaultAction]
        public ActionResult List([Bind(Prefix = "id")] int pageNumber = 1)
        {
            var paged = Posts.Page(pageNumber - 1, Config.MaxPostsPerPage);
            return View(new PostListViewModel
                            {
                                Set = paged.Set,
                                NumberOfPages = paged.NumberOfPages,
                                DescriptionLength = Config.DescriptionLength,
                                WhatIsListed = "Recent Posts.."
                            });
        }

        public ActionResult Tag(string tag, int page = 1)
        {
            var tagEntity = Tags.Get(tag);
            var paged = Posts.Page(tagEntity, page - 1, Config.MaxPostsPerPage);
            return View("List", new PostListViewModel
                                    {
                                        Set = paged.Set,
                                        NumberOfPages = paged.NumberOfPages,
                                        DescriptionLength = Config.DescriptionLength,
                                        WhatIsListed = "Posts tagged with <em>" + tag + "</em>"
                                    });
        }


        public ActionResult Archive(int year, string month)
        {
            return View("List", new PostListViewModel
                                    {
                                        Set = Posts.Archive(year, Constants.Months[month]),
                                        NumberOfPages = 1,
                                        DescriptionLength = Config.DescriptionLength,
                                        WhatIsListed =
                                            string.Format("Archived for {0:MMMM, yyyy}",
                                                          new DateTime(year, Constants.Months[month], 1))
                                    });
        }

        [LoggedIn]
        public ActionResult Delete(string id)
        {
            /* Todo : Need to figure out a way to delete without fetching */
            var post = Posts.Get(id);
            post.Tags.Clear();
            Posts.Delete(post);
            Posts.Commit();
            return RedirectToAction("List", "Blog");
        }
    }
}