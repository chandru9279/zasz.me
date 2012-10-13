using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;
using zasz.me.Integration.MVC;
using zasz.me.Models;
using zasz.me.ViewModels;

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
        public ActionResult Unlock(string returnUrl)
        {
            return View(new UnlockerModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [Secure]
        public ActionResult Unlock(UnlockerModel model)
        {
            var algorithm = new SHA256Cng();
            var unicoding = new UnicodeEncoding();
            var hashed = unicoding.GetString(algorithm.ComputeHash(unicoding.GetBytes(model.Passphrase)));
            if (hashed == "嘃ᥐ倹⦦듑ꈳ囬쀺诫谾臭ᰠ屯")
            {
                FormsAuthentication.SetAuthCookie("Manager", false);
                var url = GetHttpUrl(model.ReturnUrl ?? Url.Action("Unlock"));
                return Redirect(url);
            }
            ModelState.AddModelError("AuthenticationFailed", "Wrong Passphrase");
            return View();
        }

        [Secure]
        public ActionResult Lock()
        {
            FormsAuthentication.SignOut();
            return Redirect(GetHttpUrl("/Home"));
        }

        private string GetHttpUrl(string path)
        {
            return string.Format("http://{0}:{1}{2}", Request.Url.Host, Request.Url.Port, path);
        }
    }
}