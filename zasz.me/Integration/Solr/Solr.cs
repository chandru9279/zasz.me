using System.Web;
using SolrNet;
using Autofac;
using zasz.me.Models;
using zasz.me.Services.Contracts;

namespace zasz.me.Integration.Solr
{
    public class Solr
    {
        public static void Setup()
        {
            var server = Big.Box.Resolve<IConfigurationService>().Settings.Solr;
            if (HttpContext.Current.IsDebuggingEnabled)
                Startup.Init<Post>(new ConsoleLoggingConnection(server));
            else
                Startup.Init<Post>(server);
            RegisterOperations();
        }

        private static void RegisterOperations()
        {
            var newBuilder = new ContainerBuilder();
            newBuilder.Register(x => Startup.Container.GetInstance<ISolrOperations<Post>>());
            newBuilder.Register(x => Startup.Container.GetInstance<ISolrConnection>());
            newBuilder.Update(Big.Box);
        }
    }
}