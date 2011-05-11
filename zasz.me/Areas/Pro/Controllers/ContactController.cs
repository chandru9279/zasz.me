using System.Web.Mvc;
using zasz.me.Integration.MVC;

namespace zasz.me.Areas.Pro.Controllers
{
    public class ContactController : BaseController
    {
        [DefaultAction]
        public ActionResult Form()
        {
            return View();
        }

    }
}
