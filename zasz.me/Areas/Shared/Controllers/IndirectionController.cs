using System.Web.Mvc;

namespace zasz.me.Areas.Shared.Controllers
{
    /* Need to delete this controller and use Routing to do this*/
    public class IndirectionController : Controller
    {
        public ActionResult Favicon()
        {
            return new FilePathResult("~/Content/favicon.png", "image/png");
        }
    }
}