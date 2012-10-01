using System.Web.Mvc;
using System.Web.Routing;

namespace zasz.me.Integration.MVC
{
    public class Mvc
    {
        public static void Setup()
        {
            RegisterRoutes(RouteTable.Routes);
            SetupRazor();
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{CustomEndpoint}.axd");
            routes.IgnoreRoute("Content/{*AnyFile}");
            routes.MapRoute(
                "Favicon", 
                "favicon.ico",
                new {controller = "Home", action = "Favicon"}
                );

            routes.MapRoute(
                "TagRouting",
                "Blog/Tag/{tag}/{page}",
                new {controller = "Blog", action = "Tag", page = UrlParameter.Optional}
                );

            routes.MapRoute(
                "ArchiveRouting",
                "Blog/Archive/{year}/{month}",
                new {controller = "Blog", action = "Archive"}
                );

            routes.MapRoute(
                "Usual",
                "{controller}/{action}/{id}",
                new {controller = "Home", action = "Default", id = UrlParameter.Optional}
                );

            routes.MapRoute(
                "NotFound-Catch-All",
                "{*Url}",
                new {controller = "Error", action = "NotFound"}
                );
        }

        /* Eliminated all vbhtml and aspx, and unused locations, and engines*/

        private static void SetupRazor()
        {
            ViewEngines.Engines.Clear();
            var razor = new RazorViewEngine();
            var areaViewLocations = new string[0];
            // Not using areas, not using vbhtmls.
            var viewLocations = new[]
                                    {
                                        "~/Views/{1}/{0}.cshtml",
                                        "~/Views/Shared/{0}.cshtml"
                                    };
            razor.AreaMasterLocationFormats = areaViewLocations;
            razor.AreaPartialViewLocationFormats = areaViewLocations;
            razor.AreaViewLocationFormats = areaViewLocations;
            razor.MasterLocationFormats = viewLocations;
            razor.PartialViewLocationFormats = viewLocations;
            razor.ViewLocationFormats = viewLocations;
            ViewEngines.Engines.Add(razor);
        }
    }
}