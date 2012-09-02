using System.Web.Mvc;
using System.Web.Routing;
using Domain = zasz.me.Areas.Shared.Models.Site;

namespace zasz.me.Integration.MVC
{
    public class MvcIntegration
    {
        public static void Bootstrap()
        {
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            SetupRazor();
        }

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
            Routes.MapRoute("Favicon", "favicon.ico",
                            new {Controller = "Indirection", Action = "Favicon"}).DataTokens["area"] = "Shared";


            AreaRegistration.RegisterAllAreas();

            DomainMappedRoute(
                Routes,
                "TagRouting",
                "Blog/Tag/{TagName}/{PageNumber}",
                new {Controller = "Blog", Action = "Tag", PageNumber = UrlParameter.Optional}
                );

            DomainMappedRoute(
                Routes,
                "ArchiveRouting",
                "Blog/Archive/{Year}/{Month}",
                new {Controller = "Blog", Action = "Archive"}
                );

            DomainMappedRoute(
                Routes,
                "Usual",
                "{Controller}/{Action}/{Id}",
                new {Controller = "Home", Action = "Default", Id = UrlParameter.Optional}
                );

            DomainMappedRoute(
                Routes,
                "NotFound-Catch-All",
                "{*Url}",
                new {controller = "Error", action = "NotFound"}
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
                new {DomainConstraint = new DomainRouteConstraint("zasz.me")}
                ).DataTokens["area"] = Domain.PRO;

            Routes.MapRoute(
                "localhost " + RouteName,
                Pattern,
                Defaults,
                new {DomainConstraint = new DomainRouteConstraint("localhost")}
                ).DataTokens["area"] = Domain.PRO;

            Routes.MapRoute(
                "chandruon.net " + RouteName,
                Pattern,
                Defaults,
                new {DomainConstraint = new DomainRouteConstraint("chandruon.net")}
                ).DataTokens["area"] = Domain.PRO;
        }

        /* Eliminated all vbhtml and aspx, and unused locations, and engines*/
        private static void SetupRazor()
        {
            ViewEngines.Engines.Clear();
            var Razor = new RazorViewEngine();
            var AreaViewLocations = new[]
                                        {
                                            "~/Areas/{2}/Views/{1}/{0}.cshtml",
                                            "~/Areas/{2}/Views/Shared/{0}.cshtml"
                                        };
            // Not using anything outside of the areas.
            var ViewLocations = new string[0];
            Razor.AreaMasterLocationFormats = AreaViewLocations;
            Razor.AreaPartialViewLocationFormats = AreaViewLocations;
            Razor.AreaViewLocationFormats = AreaViewLocations;
            Razor.MasterLocationFormats = ViewLocations;
            Razor.PartialViewLocationFormats = ViewLocations;
            Razor.ViewLocationFormats = ViewLocations;
            ViewEngines.Engines.Add(Razor);
        }
    }
}