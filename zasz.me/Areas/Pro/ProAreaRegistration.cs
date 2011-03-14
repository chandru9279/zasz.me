using System.Web.Mvc;
using zasz.me.Models;

namespace zasz.me.Areas.Pro
{
    public class ProAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "Pro"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Pro_Home",
                "Pro/{controller}/{action}/{id}",
                new {controller = "Home", action = "Show", id = UrlParameter.Optional}
                );
            Site.Register("chandruon.net", AreaName);
            Site.Register("localhost", AreaName);
        }
    }
}