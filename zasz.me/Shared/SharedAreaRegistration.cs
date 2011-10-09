using System.Web.Mvc;
using zasz.me.Shared.Models;

namespace zasz.me.Shared
{
    public class SharedAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return Site.SHARED; }
        }

        public override void RegisterArea(AreaRegistrationContext Context)
        {
            Context.MapRoute(
                "Shared_default",
                "Shared/{controller}/{action}/{id}",
                new {Controller = "Home", Action = "Default", id = UrlParameter.Optional}
                );

        }
    }
}