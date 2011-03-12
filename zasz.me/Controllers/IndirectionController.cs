using System.Web.Mvc;
using zasz.me.Controllers.Utils;

namespace zasz.me.Controllers
{
    public class IndirectionController : Controller
    {
        public ActionResult Indirect()
        {
            return new TransferResult(Models.Areas.Url(Request.Url.Host));
        }
    }
}