using System.Web.Mvc;

namespace zasz.me.Areas.Pro.Controllers
{
    public class ErrorController : Controller
    {

        public ActionResult Broken()
        {
            return View();
        }

    }
}
