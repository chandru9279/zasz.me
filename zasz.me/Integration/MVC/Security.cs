using System.Web.Mvc;

namespace zasz.me.Integration.MVC
{
    public sealed class Secure : RequireHttpsAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var skipAuthorization = filterContext.HttpContext.Request.IsLocal;
            if (!skipAuthorization)
                base.OnAuthorization(filterContext);
        }
    }

    public sealed class LoggedIn : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
//            var skipAuthorization = filterContext.HttpContext.Request.IsLocal;
//            if (!skipAuthorization)
                base.OnAuthorization(filterContext);
        }
    }
}