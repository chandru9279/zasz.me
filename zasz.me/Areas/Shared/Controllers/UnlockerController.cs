using System;
using System.Web.Mvc;
using System.Web.Security;
using zasz.me.Areas.Shared.Models;
using zasz.me.Integration.MVC;

namespace zasz.me.Areas.Shared.Controllers
{
    [AllowAnonymous]
    public class UnlockerController : BaseController
    {
        private readonly IPassphraseRepository _PassphraseRepository;

        public UnlockerController(IPassphraseRepository PassphraseRepository)
        {
            _PassphraseRepository = PassphraseRepository;
        }

        [DefaultAction]
        public ActionResult Unlock()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Unlock(string PassPhrase, string ReturnUrl)
        {
//            if (_PassphraseRepository.Authenticate(PassPhrase))
            if (PassPhrase == "JustPass")
            {
                FormsAuthentication.SetAuthCookie("Manager", false);
                return Redirect(ReturnUrl);
            }
            ModelState.AddModelError("AuthenticationFailed", "Wrong Passphrase");
            return View();
        }

        public ActionResult Lock(string Controller = "Home", string Action = "Show")
        {
            FormsAuthentication.SignOut();
            return RedirectToAction(Action, Controller);
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public sealed class AllowAnonymousAttribute : Attribute
    {
    }

    public sealed class LogonAuthorize : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext FilterContext)
        {
            bool SkipAuthorization = FilterContext.ActionDescriptor.
                                         IsDefined(typeof (AllowAnonymousAttribute), true) ||
                                     FilterContext.ActionDescriptor.ControllerDescriptor
                                         .IsDefined(typeof (AllowAnonymousAttribute), true);
            if (!SkipAuthorization)
                base.OnAuthorization(FilterContext);
        }
    }
}