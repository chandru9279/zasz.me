using System.Web.Mvc;

namespace zasz.me.Areas.Pro.Controllers
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
        
        public ActionResult About()
        {
            return View();
        }
    }
}
