using System.Web.Mvc;

namespace zasz.me.Areas.Pro.Controllers
{
    public class ContactController : Controller
    {
        public ActionResult Default()
        {
            return RedirectToAction("Form");
        }

        public ActionResult Form()
        {
            return View();
        }

    }
}
