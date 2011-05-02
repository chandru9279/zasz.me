using System.Web.Mvc;

namespace zasz.me.Areas.Pro.Controllers
{
    public class PortfolioController : Controller
    {
        public ActionResult Default()
        {
            return RedirectToAction("All");
        }

        public ActionResult All()
        {
            return View();
        }

    }
}
