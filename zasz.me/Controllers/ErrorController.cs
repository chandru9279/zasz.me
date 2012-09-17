using System.Web.Mvc;
using zasz.me.Integration.MVC;

namespace zasz.me.Controllers
{
    public class ErrorController : BaseController
    {
        [DefaultAction]
        public ActionResult NotFound(string actionName = "")
        {
            ViewBag.OriginalAction = RouteData.DataTokens["OriginalAction"];
            ViewBag.OriginalController = RouteData.DataTokens["OriginalController"];
            ViewBag.OriginalUrl = RouteData.Values["Url"];
            ViewBag.MissingAction = actionName;
            return View(RouteData.DataTokens["OriginalError"]);
        }
    }
}