using System.Web.Mvc;
using zasz.me.Integration.MVC;

namespace zasz.me.Controllers
{
    /* Need to delete this controller and use Routing to do this*/
    public class IndirectionController : BaseController
    {
        [DefaultAction]
        public ActionResult Favicon()
        {
            return new FilePathResult("~/Content/favicon.png", "image/png");
        }
    }
}