using System.Web.Mvc;
using zasz.me.Integration.MVC;

namespace zasz.me.Rest.Controllers
{
    public class AboutController : BaseController
    {
        [DefaultAction]
        public ActionResult Me()
        {
            return View();
        }

    }
}
