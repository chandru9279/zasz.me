using System.Web.Mvc;
using zasz.me.Controllers;
using zasz.me.Models;

namespace zasz.me.Areas.Pro.Controllers
{
    public class WritingsController : PostController
    {
        private readonly Site _Pro;

        public WritingsController(IPostRepository Posts, ITagRepository Tags) : base(Posts, Tags)
        {
            _Pro = Site.WithName("Pro");
        }

        public ActionResult Default()
        {
            return RedirectToAction("List");
        }

        public ActionResult List(int Id = 0)
        {
            return List(_Pro, Id);
        }

        public ActionResult Tag(string TagName, int PageNumber = 0)
        {
            return Tag(_Pro, TagName, PageNumber);
        }
    }
}