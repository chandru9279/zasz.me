using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using zasz.me.Integration;
using zasz.me.Integration.EntityFramework;
using zasz.me.Integration.MVC;
using Domain = zasz.me.Areas.Shared.Models.Site;

namespace zasz.me
{
    public class ZaszDotMe : HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection Filters)
        {
            //Filters.Add(new HandleErrorAttribute());
            //Filters.Add(new LogonAuthorize());
            //Filters.Add(new RequireHttpsAttribute());
        }

        public static void RegisterRoutes(RouteCollection Routes)
        {
            Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            Routes.IgnoreRoute("{CustomEndpoint}.axd");
            Routes.IgnoreRoute("Content/");
            Routes.IgnoreRoute("Uploads/{*AnyFile}");
            Routes.IgnoreRoute("Integration/ckeditor");
            
            AreaRegistration.RegisterAllAreas();
            
            DomainMappedRoute(
                Routes,
                "TagRouting",
                "Writings/Tag/{TagName}/{PageNumber}",
                new { Controller = "Writings", Action = "Tag", PageNumber = UrlParameter.Optional }
                );

            DomainMappedRoute(
                Routes,
                "ArchiveRouting",
                "Writings/Archive/{Year}/{Month}",
                new { Controller = "Writings", Action = "Archive" }
                );

            DomainMappedRoute(
                Routes,
                "Usual",
                "{Controller}/{Action}/{Id}",
                new { Controller = "Home", Action = "Default", Id = UrlParameter.Optional }
                );
        }

        /* Routing based on Domain to Areas : 
             * http://www.asp.net/mvc/tutorials/creating-a-custom-route-constraint-cs,
             * http://suhair.in/Blog/Aspnet-MVC-Areas-in-depth-Part-2
             * 
             * The following routes will auto add area tokens, based on Domains, only if no area name is given in the first place.
             * If Area name is explicitly mentioned, the routes in the AreaRegistration take over.
             * The following 3 will conflict, if the DomainRouteConstraint is removed.
             */

        private static void DomainMappedRoute(RouteCollection Routes, string RouteName, string Pattern, object Defaults)
        {
            Routes.MapRoute("Pro " + RouteName, "Pro/" + Pattern, Defaults).DataTokens["area"] = Domain.PRO;
            Routes.MapRoute("Rest " + RouteName, "Rest/" + Pattern, Defaults).DataTokens["area"] = Domain.REST;

            Routes.MapRoute(
                "zasz.me " + RouteName,
                Pattern,
                Defaults,
                new { DomainConstraint = new DomainRouteConstraint("zasz.me") }
                ).DataTokens["area"] = Domain.PRO;

            Routes.MapRoute(
                "localhost " + RouteName,
                Pattern,
                Defaults,
                new { DomainConstraint = new DomainRouteConstraint("localhost") }
                ).DataTokens["area"] = Domain.PRO;

            Routes.MapRoute(
                "chandruon.net " + RouteName,
                Pattern,
                Defaults,
                new { DomainConstraint = new DomainRouteConstraint("chandruon.net") }
                ).DataTokens["area"] = Domain.PRO;
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