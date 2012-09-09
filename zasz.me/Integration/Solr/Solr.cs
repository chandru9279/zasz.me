using System.Web;
using Microsoft.Practices.Unity;
using SolrNet;
using zasz.me.Models;

namespace zasz.me.Integration.Solr
{
    public class Solr
    {
        public static void Setup()
        {
            var server = Big.Box.Resolve<string>("SolrServer");
            if (HttpContext.Current.IsDebuggingEnabled)
                Startup.Init<Post>(new ConsoleLoggingConnection(server));
            else
                Startup.Init<Post>(server);
            Big.Box.RegisterType<ISolrOperations<Post>>( 
                new InjectionFactory(x => Startup.Container.GetInstance<ISolrOperations<Post>>())
                );
        }
    }
}