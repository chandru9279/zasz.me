using System.Web.Mvc;
using zasz.me.Integration.MVC;

namespace zasz.me.Areas.Shared.Controllers
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
