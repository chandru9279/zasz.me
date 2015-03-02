using System.Web.Mvc;
using System.Web.Routing;
using System.Web.WebPages;

using RazorGenerator.Mvc;

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
            routes.MapRoute("Favicon", "favicon.ico", new { controller = "Home", action = "Favicon" });

            routes.MapRoute(
                "ContentRoutingForTrailingSlashUrls",
                "Blog/Post/{slug}/PostContent/{contentName}",
                new { controller = "Blog", action = "PostContent" });

            routes.MapRoute(
                "ContentRoutingForNoTrailingSlash",
                "Blog/Post/PostContent/{contentName}",
                new { controller = "Blog", action = "PostContentInferSlug" });

            routes.MapRoute(
                "TagRouting",
                "Blog/Tag/{tag}/{page}",
                new { controller = "Blog", action = "Tag", page = UrlParameter.Optional });

            routes.MapRoute(
                "ArchiveRouting",
                "Blog/Archive/{year}/{month}",
                new { controller = "Blog", action = "Archive" });

            routes.MapRoute(
                "Usual",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "ToBlog", id = UrlParameter.Optional });

            routes.MapRoute("NotFound-Catch-All", "{*Url}", new { controller = "Error", action = "NotFound" });
        }

        /* Eliminated all vbhtml and aspx, and unused locations, and engines*/
        private static void SetupRazor()
        {
            ViewEngines.Engines.Clear();

            var razor = new PrecompiledMvcEngine(typeof(Mvc).Assembly)
                            {
                                UsePhysicalViewsIfNewer = true
                            };

            ViewEngines.Engines.Insert(0, razor);

            // StartPage lookups are done by WebPages.
            VirtualPathFactoryManager.RegisterVirtualPathFactory(razor);

            // Not using areas, not using vbhtmls.
            var areaViewLocations = new string[0];
            var viewLocations = new[] { "~/Views/{1}/{0}.cshtml", "~/Views/Shared/{0}.cshtml" };
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