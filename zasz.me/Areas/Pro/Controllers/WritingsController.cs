using System;
using System.Linq;
using System.Web.Mvc;
using zasz.me.Areas.Shared.Controllers;
using zasz.me.Areas.Shared.Controllers.Utils;
using zasz.me.Areas.Shared.Models;
using zasz.me.Integration.MVC;

namespace zasz.me.Areas.Pro.Controllers
{
    public class WritingsController : PostController
    {
        private readonly Site _Pro;

        public WritingsController(IPostRepository Posts, ITagRepository Tags) : base(Posts, Tags)
        {
            _Pro = Site.WithName("Pro");
        }

        [DefaultAction]
        public ActionResult List(int Id = 1)
        {
            return List(_Pro, Id);
        }

        public ActionResult Post([Bind(Prefix = "Id")]string Slug)
        {
            return View(_Posts.Get(Slug));
        }

        public ActionResult Tag(string TagName, int PageNumber = 1)
        {
            return Tag(_Pro, TagName, PageNumber);
        }

        /* Use Handy.InvalidateOutputCache() when Creating a Post to manually expire this cache*/
        [OutputCache(Duration = 3600)]
        public ActionResult ArchiveControl()
        {
            return ArchiveControl(_Pro);
        }

        public ActionResult Archive(int Year, string Month)
        {
            return Archive(_Pro, Year, Constants.Months[Month]);
        }
    }
}