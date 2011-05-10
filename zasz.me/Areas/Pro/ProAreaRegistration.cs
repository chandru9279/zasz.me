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
                "TagRouting",
                "Writings/Tag/{TagName}/{PageNumber}",
                new { Controller = "Writings", Action = "Tag", PageNumber = UrlParameter.Optional }
                );

            context.MapRoute(
                "ArchiveRouting",
                "Writings/Archive/{Year}/{Month}",
                new { Controller = "Writings", Action = "Archive" }
                );

            Site.Register("chandruon.net", Domain.Pro);
        }
    }
}