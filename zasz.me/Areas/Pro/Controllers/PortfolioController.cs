using System.Web.Mvc;
using zasz.me.Integration.MVC;

namespace zasz.me.Areas.Pro.Controllers
{
    public class PortfolioController : BaseController
    {
        [DefaultAction]
        public ActionResult All()
        {
            return View();
        }

    }
}
