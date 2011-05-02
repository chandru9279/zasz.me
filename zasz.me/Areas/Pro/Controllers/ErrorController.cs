using System.Web.Mvc;

namespace zasz.me.Areas.Pro.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Default()
        {
            return RedirectToAction("Broken");
        }

        public ActionResult Broken()
        {
            return View();
        }

    }
}
