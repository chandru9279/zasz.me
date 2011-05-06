using System.Web.Mvc;
using System.Web.Security;
using zasz.me.Areas.Shared.Models;

namespace zasz.me.Areas.Shared.Controllers
{
    public abstract class UnlockerController : Controller
    {
        private readonly IPassphraseRepository _PassphraseRepository;

        protected UnlockerController(IPassphraseRepository PassphraseRepository)
        {
            _PassphraseRepository = PassphraseRepository;
        }

        public ActionResult Unlock(string Controller = "Home", string Action = "Show")
        {
            ViewBag.Controller = Controller;
            ViewBag.Action = Action;
            return View();
        }

        [HttpPost]
        public ActionResult Unlock(string PassPhrase, string Controller, string Action)
        {
            if (_PassphraseRepository.Authenticate(PassPhrase))
            {
                FormsAuthentication.SetAuthCookie("Manager", false);
                return RedirectToAction(Action, Controller);
            }
            return RedirectToAction(Action, Controller);
        }

        public ActionResult Lock(string Controller = "Home", string Action = "Show")
        {
            FormsAuthentication.SignOut();
            return RedirectToAction(Action, Controller);
        }
    }
}