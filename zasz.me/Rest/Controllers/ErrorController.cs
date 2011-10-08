using System.Web.Mvc;
using zasz.me.Integration.MVC;

namespace zasz.me.Areas.Rest.Controllers
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
