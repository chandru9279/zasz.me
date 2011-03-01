using System.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Raven.Client.Document;
using zasz.me.Integration;

namespace zasz.me
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection Filters)
        {
            Filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection Routes)
        {
            Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            Routes.IgnoreRoute("{CustomEndpoint}.axd");

            Routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            UseUnityDIForControllers();
            UseRavenDB();
        }

        private static void UseUnityDIForControllers()
        {
            var BigBox = new UnityContainer();
            var Section = ConfigurationManager.GetSection("Unity") as UnityConfigurationSection;
            if (Section != null) Section.Configure(BigBox, "BigBox");
            ControllerBuilder.Current.SetControllerFactory(new UnityControllerBuilder(BigBox));
            HugeBox.Swallow(BigBox);
        }

        private static void UseRavenDB()
        {
            var DocumentStore = new DocumentStore { ConnectionStringName = "RavenConnection" };
            DocumentStore.Initialize();
            HugeBox.Swallow(DocumentStore);
        }
    }
}