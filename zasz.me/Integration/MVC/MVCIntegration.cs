using System.Web.Mvc;
using System.Web.Routing;
using Domain = zasz.me.Models.Site;

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
            Routes.IgnoreRoute("Content/{*AnyFile}");
            Routes.IgnoreRoute("Uploads/{*AnyFile}");
            Routes.IgnoreRoute("Integration/ckeditor");
            Routes.MapRoute("Favicon", "favicon.ico",
                            new {Controller = "Indirection", Action = "Favicon"}).DataTokens["area"] = "Shared";

            Routes.MapRoute(
                "TagRouting",
                "Blog/Tag/{TagName}/{PageNumber}",
                new {Controller = "Blog", Action = "Tag", PageNumber = UrlParameter.Optional}
                );

            Routes.MapRoute(
                "ArchiveRouting",
                "Blog/Archive/{Year}/{Month}",
                new {Controller = "Blog", Action = "Archive"}
                );

            Routes.MapRoute(
                "Usual",
                "{Controller}/{Action}/{Id}",
                new {Controller = "Home", Action = "Default", Id = UrlParameter.Optional}
                );

            Routes.MapRoute(
                "NotFound-Catch-All",
                "{*Url}",
                new {controller = "Error", action = "NotFound"}
                );
        }
        
        /* Eliminated all vbhtml and aspx, and unused locations, and engines*/

        private static void SetupRazor()
        {
            ViewEngines.Engines.Clear();
            var Razor = new RazorViewEngine();
            var AreaViewLocations = new string[0];
            // Not using areas, not using vbhtmls.
            var ViewLocations = new[]
                                    {
                                        "~/Views/{1}/{0}.cshtml",
                                        "~/Views/Shared/{0}.cshtml"
                                    };
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