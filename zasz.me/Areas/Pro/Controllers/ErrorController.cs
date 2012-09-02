using System.Web.Mvc;
using zasz.me.Integration.MVC;

namespace zasz.me.Areas.Pro.Controllers
{
    public class ErrorController : BaseController
    {
        [DefaultAction]
        public ActionResult NotFound(string ActionName = "")
        {
            ViewBag.OriginalAction = RouteData.DataTokens["OriginalAction"];
            ViewBag.OriginalController = RouteData.DataTokens["OriginalController"];
            ViewBag.OriginalUrl = RouteData.Values["Url"];
            ViewBag.MissingAction = ActionName;
            return View(RouteData.DataTokens["OriginalError"]);
        }
    }
}
