using System.Web.Mvc;
using zasz.me.Controllers.Utils;
using zasz.me.Models;

namespace zasz.me.Controllers
{
    public class IndirectionController : Controller
    {
        public ActionResult Indirect()
        {
            return new TransferResult(Site.WithHost(Request.Url.Host).VirtualPath);
        }

        public ActionResult Favicon()
        {
            return new FilePathResult("~/Content/favicon.png", "image/png");
        }
    }
}