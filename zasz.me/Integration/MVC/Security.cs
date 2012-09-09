using System.Web.Mvc;

namespace zasz.me.Integration.MVC
{
    public sealed class Secure : RequireHttpsAttribute
    {
        public override void OnAuthorization(AuthorizationContext FilterContext)
        {
            var SkipAuthorization = FilterContext.HttpContext.Request.IsLocal;
            if (!SkipAuthorization)
                base.OnAuthorization(FilterContext);
        }
    }
}