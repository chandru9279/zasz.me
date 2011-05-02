using System.Web.Mvc;

namespace zasz.me.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Default()
        {
            return RedirectToAction("Show");
        }

        public ActionResult Show()
        {
            return View();
        }

    }
}
