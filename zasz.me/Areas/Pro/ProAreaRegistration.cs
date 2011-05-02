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
                "PostRouting",
                "Pro/Writings/Tag/{TagName}/{PageNumber}",
                new { Controller = "Writings", Action = "Tag", PageNumber = UrlParameter.Optional }
                );

            context.MapRoute(
                "Pro_Home",
                "Pro/{Controller}/{Action}/{Id}",
                new {Controller = "Home", Action = "Default", Id = UrlParameter.Optional}
                );
            Site.Register("chandruon.net", AreaName);
            Site.Register("localhost", AreaName);
        }
    }
}