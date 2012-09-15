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

        public static void RegisterRoutes(RouteCollection Routes)
        {
            Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            Routes.IgnoreRoute("{CustomEndpoint}.axd");
            Routes.IgnoreRoute("Content/{*AnyFile}");
            Routes.IgnoreRoute("Uploads/{*AnyFile}");
            Routes.IgnoreRoute("Integration/ckeditor");
            Routes.MapRoute("Favicon", "favicon.ico",
                            new {controller = "Indirection", action = "Favicon"}).DataTokens["area"] = "Shared";

            Routes.MapRoute(
                "TagRouting",
                "Blog/Tag/{tag}/{page}",
                new {controller = "Blog", action = "Tag", page = UrlParameter.Optional}
                );

            Routes.MapRoute(
                "ArchiveRouting",
                "Blog/Archive/{year}/{month}",
                new {controller = "Blog", action = "Archive"}
                );

            Routes.MapRoute(
                "Usual",
                "{controller}/{action}/{id}",
                new {controller = "Home", action = "Default", id = UrlParameter.Optional}
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