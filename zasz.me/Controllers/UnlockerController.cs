using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace zasz.me.Controllers
{
    public class UnlockerController : Controller
    {

        public ActionResult Unlock(string Controller = "Home", string Action = "Show")
        {
            ViewBag.Controller = Controller;
            ViewBag.Action = Action;
            return View();
        }

        [HttpPost]
        public ActionResult Unlock(string PassPhrase, string Controller, string Action)
        {
            // Compare PassPhrase
            FormsAuthentication.SetAuthCookie("Manager", false);
            return RedirectToAction(Action, Controller);
        }

        public ActionResult Lock(string Controller = "Home", string Action = "Show")
        {
            FormsAuthentication.SignOut();
            return RedirectToAction(Action, Controller);
        }
    }
}
