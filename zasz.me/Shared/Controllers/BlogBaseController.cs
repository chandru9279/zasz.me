using System.Web.Mvc;
using zasz.me.Integration.MVC;
using zasz.me.Shared.Controllers.Utils;
using zasz.me.Shared.Models;

namespace zasz.me.Shared.Controllers
{
    public class BlogBaseController : PostController
    {
        protected readonly Site _Site;

        public BlogBaseController(IPostRepository Posts, ITagRepository Tags, Site Domain) : base(Posts, Tags)
        {
            _Site = Domain;
        }

        [DefaultAction]
        public ActionResult List(int Id = 1)
        {
            return List(_Site, Id);
        }

        public ActionResult Post([Bind(Prefix = "Id")]string Slug)
        {
            return View(_Posts.Get(Slug));
        }

        public ActionResult Tag(string TagName, int PageNumber = 1)
        {
            return Tag(_Site, TagName, PageNumber);
        }

        /* Use Handy.InvalidateOutputCache() when Creating a Post to manually expire this cache*/
        [OutputCache(Duration = 3600)]
        public ActionResult ArchiveControl()
        {
            return ArchiveControl(_Site);
        }

        public ActionResult Archive(int Year, string Month)
        {
            return Archive(_Site, Year, Constants.Months[Month]);
        }

        [OutputCache(Duration = 10)]
        public ActionResult TagCloudControl()
        {
            return TagCloud(_Site, 214, 500);
        }
    }
}
