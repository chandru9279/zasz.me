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
            Models.Areas.Add(Area.Pro, "chandruon.net", AreaName);
            Models.Areas.Add(Area.Pro, "localhost", AreaName);
        }
    }
}