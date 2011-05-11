using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using zasz.me.Integration;
using zasz.me.Integration.EntityFramework;
using zasz.me.Integration.MVC;

namespace zasz.me
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class ZaszDotMe : HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection Filters)
        {
            Filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection Routes)
        {
            Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            Routes.IgnoreRoute("{CustomEndpoint}.axd");
            Routes.IgnoreRoute("Content/");
            Routes.IgnoreRoute("Integration/ckeditor");
            

            /* Routing based on Domain to Areas : 
             * http://www.asp.net/mvc/tutorials/creating-a-custom-route-constraint-cs,
             * http://suhair.in/Blog/Aspnet-MVC-Areas-in-depth-Part-2
             * 
             * The following routes will auto add area tokens, based on Domains, only if no area name is given in the first place.
             * If Area name is explicitly mentioned, the routes in the AreaRegistration take over.
             * The following 3 will conflict, if the DomainRouteConstraint is removed.
             */

            AreaRegistration.RegisterAllAreas();

            Routes.MapRoute(
                "zasz.me Route",
                "{Controller}/{Action}/{Id}",
                new {Controller = "Home", Action = "Default", Id = UrlParameter.Optional},
                new {DomainConstraint = new DomainRouteConstraint("zasz.me")}
                ).DataTokens["area"] = "Pro";

            Routes.MapRoute(
                "localhost Route",
                "{Controller}/{Action}/{Id}",
                new { Controller = "Home", Action = "Default", Id = UrlParameter.Optional },
                new {DomainConstraint = new DomainRouteConstraint("localhost")}
                ).DataTokens["area"] = "Pro";

            Routes.MapRoute(
                "chandruon.net Route",
                "{Controller}/{Action}/{Id}",
                new { Controller = "Home", Action = "Default", Id = UrlParameter.Optional },
                new {DomainConstraint = new DomainRouteConstraint("chandruon.net")}
                ).DataTokens["area"] = "Pro";
        }

        protected void Application_Start()
        {
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
            UnityIntegration.Bootstrap();
            EntityFramework.Bootstrap();
        }
    }
}