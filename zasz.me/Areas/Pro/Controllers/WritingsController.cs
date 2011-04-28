using System.Web.Mvc;
using zasz.me.Controllers;
using zasz.me.Models;

namespace zasz.me.Areas.Pro.Controllers
{
    public class WritingsController : PostController
    {
        public WritingsController(IPostRepository Posts) : base(Posts)
        {
        }

        public ActionResult List(int PageNumber = 0)
        {
            return List(Site.WithName("Pro"), PageNumber);
        }

    }
}
