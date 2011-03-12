using System.Web;
using System.Web.Mvc;

namespace zasz.me.Controllers.Utils
{
    public class TransferResult : RedirectResult
    {
        public TransferResult(string url)
            : base(url)
        {
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var Context = HttpContext.Current;
            Context.RewritePath(Url, false);

            IHttpHandler Handler = new MvcHttpHandler();
            Handler.ProcessRequest(HttpContext.Current);
        }
    }
}