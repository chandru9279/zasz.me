using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;
using zasz.me.Integration.MVC;
using zasz.me.Models;

namespace zasz.me.Controllers
{
    public class UnlockerController : BaseController
    {
        private readonly IPassphraseRepository repository;

        public UnlockerController(IPassphraseRepository repository)
        {
            this.repository = repository;
        }

        [DefaultAction]
        [Secure]
        public ActionResult Unlock()
        {
            return View();
        }

        [HttpPost]
        [Secure]
        public ActionResult Unlock(string passphrase, string returnUrl)
        {
            var algorithm = new SHA256Cng();
            var unicoding = new UnicodeEncoding();
            var hashed = unicoding.GetString(algorithm.ComputeHash(unicoding.GetBytes(passphrase)));
            if (hashed == "嘃ᥐ倹⦦듑ꈳ囬쀺诫谾臭ᰠ屯") 
            {
                FormsAuthentication.SetAuthCookie("Manager", false);
                return Redirect(returnUrl ?? "/Home");
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