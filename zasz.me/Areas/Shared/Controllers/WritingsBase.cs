using System.Web.Mvc;
using zasz.me.Areas.Shared.Controllers.Utils;
using zasz.me.Areas.Shared.Models;
using zasz.me.Integration.MVC;

namespace zasz.me.Areas.Shared.Controllers
{
    public class WritingsBase : PostController
    {
        private readonly Site _Site;

        public WritingsBase(IPostRepository Posts, ITagRepository Tags, string SiteName) : base(Posts, Tags)
        {
            _Site = Site.WithName(SiteName);
        }

        [DefaultAction]
        public ActionResult List(int Id = 1)
        {
            return List(_Site, Id);
        }

        public ActionResult Post([Bind(Prefix = "Id")]string Slug)
        {
            return View(WritingsView("Post"), _Posts.Get(Slug));
        }

        public ActionResult Tag(string TagName, int PageNumber = 1)
        {
            return Tag(_Site, TagName, PageNumber);
        }

        /* Use Handy.InvalidateOutputCache() when Creating a Post to manually expire this cache*/
//        [OutputCache(Duration = 3600)]
        public ActionResult ArchiveControl()
        {
            return ArchiveControl(_Site);
        }

        public ActionResult Archive(int Year, string Month)
        {
            return Archive(_Site, Year, Constants.Months[Month]);
        }

        public static string WritingsView(string ViewName)
        {
            return string.Format("~/Areas/Shared/Views/Writings/{0}.cshtml", ViewName);
        }

    }
}
