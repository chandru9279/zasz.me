using System.Web.Mvc;
using zasz.me.Areas.Shared.Models;

namespace zasz.me.Areas.Shared
{
    public class SharedAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "Shared"; }
        }

        public override void RegisterArea(AreaRegistrationContext Context)
        {
            Context.MapRoute("Favicon", "favicon.ico", new {Controller = "Indirection", Action = "Favicon"});

            Context.MapRoute(
                "Shared_default",
                "Shared/{controller}/{action}/{id}",
                new {Controller = "Home", Action = "Default", id = UrlParameter.Optional}
                );

            Site.Register("chandruon.net", Domain.Both);
        }
    }
}