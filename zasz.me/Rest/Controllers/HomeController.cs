using System.Web.Mvc;
using zasz.me.Integration.MVC;

namespace zasz.me.Areas.Rest.Controllers
{
    public class HomeController : BaseController
    {
        [DefaultAction]
        public ActionResult Show()
        {
            return View();
        }
    }
}
