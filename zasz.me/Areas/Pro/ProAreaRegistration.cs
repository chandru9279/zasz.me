using System.Web.Mvc;
using zasz.me.Areas.Shared.Models;

namespace zasz.me.Areas.Pro
{
    public class ProAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return Domain.Pro.ToString(); }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Pro_Home",
                "Pro/{Controller}/{Action}/{Id}",
                new {Controller = "Home", Action = "Default", Id = UrlParameter.Optional}
                );
            context.MapRoute(
                "PostRouting",
                "Pro/Writings/Tag/{TagName}/{PageNumber}",
                new { Controller = "Writings", Action = "Tag", PageNumber = UrlParameter.Optional }
                );

            Site.Register("chandruon.net", Domain.Pro);
        }
    }
}