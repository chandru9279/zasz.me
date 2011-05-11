using System.Web.Mvc;
using zasz.me.Integration.MVC;

namespace zasz.me.Areas.Pro.Controllers
{
    public class ErrorController : BaseController
    {
        [DefaultAction]
        public ActionResult Broken()
        {
            return View();
        }

    }
}
