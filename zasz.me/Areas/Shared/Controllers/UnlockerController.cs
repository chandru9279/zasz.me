using System.Web.Mvc;
using System.Web.Security;
using zasz.me.Areas.Shared.Models;
using zasz.me.Integration.MVC;

namespace zasz.me.Areas.Shared.Controllers
{
    public abstract class UnlockerController : BaseController
    {
        private readonly IPassphraseRepository _PassphraseRepository;

        protected UnlockerController(IPassphraseRepository PassphraseRepository)
        {
            _PassphraseRepository = PassphraseRepository;
        }

        [DefaultAction]
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