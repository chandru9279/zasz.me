using System.Security.Cryptography;
using System.Text;
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
        [Secure]
        public ActionResult Unlock()
        {
            return View();
        }

        [HttpPost]
        [Secure]
        public ActionResult Unlock(string PassPhrase, string ReturnUrl)
        {
//            if (_PassphraseRepository.Authenticate(PassPhrase))
            var Algorithm = new SHA256Cng();
            var Unicoding = new UnicodeEncoding();
            string Hashed = Unicoding.GetString(Algorithm.ComputeHash(Unicoding.GetBytes(PassPhrase)));
            if (Hashed == "竽鼶੥惞⢭邽靱讘朮堢�ଣ疪糧܍") /* I put this especially for that idiot who deleted my Posts :P */
            {
                FormsAuthentication.SetAuthCookie("Manager", false);
                return Redirect(ReturnUrl ?? "/Home");
            }
            ModelState.AddModelError("AuthenticationFailed", "Wrong Passphrase");
            return View();
        }

        [Secure]
        public ActionResult Lock()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Home");
        }
    }
}