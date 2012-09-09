using System;
using System.Web.Mvc;

namespace zasz.me.Integration.MVC
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public sealed class AllowAnonymousAttribute : Attribute
    {
    }

    /// <summary>
    /// This class as a global filter will make all Controllers except those marked by
    /// <see cref="AllowAnonymousAttribute"/> as protected controllers which can be
    /// accessed only after authentication.
    /// </summary>
    public sealed class LogonAuthorize : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext FilterContext)
        {
            var SkipAuthorization = FilterContext.ActionDescriptor.
                                        IsDefined(typeof (AllowAnonymousAttribute), true) ||
                                    FilterContext.ActionDescriptor.ControllerDescriptor
                                        .IsDefined(typeof (AllowAnonymousAttribute), true);
            if (!SkipAuthorization)
                base.OnAuthorization(FilterContext);
        }
    }

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