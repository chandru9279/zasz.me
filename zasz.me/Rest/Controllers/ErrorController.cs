using System.Web.Mvc;
using zasz.me.Integration.MVC;

namespace zasz.me.Rest.Controllers
{
    public class ErrorController : BaseController
    {
        [DefaultAction]
        public ActionResult NotFound()
        {
            return View();
        }

    }
}
