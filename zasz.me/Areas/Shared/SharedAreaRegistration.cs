using System.Web.Mvc;
using zasz.me.Areas.Shared.Models;

namespace zasz.me.Areas.Shared
{
    public class SharedAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Shared";
            }
        }

        public override void RegisterArea(AreaRegistrationContext Context)
        {
            Context.MapRoute(
                "Shared_default",
                "Shared/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
            Site.Register("chandruon.net", Domain.Both);
        }
    }
}
