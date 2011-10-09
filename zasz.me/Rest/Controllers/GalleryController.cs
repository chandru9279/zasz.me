using System.Web.Mvc;
using zasz.me.Integration.MVC;

namespace zasz.me.Rest.Controllers
{
    public class GalleryController : BaseController
    {
        [DefaultAction]
        public ActionResult Look()
        {
            return View();
        }
    }
}
