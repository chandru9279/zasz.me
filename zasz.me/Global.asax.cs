using System.Web;
using zasz.me.Integration.EntityFramework;
using zasz.me.Integration.MVC;
using zasz.me.Integration.Solr;
using zasz.me.Integration.Unity;

namespace zasz.me
{
    public class ZaszDotMe : HttpApplication
    {
        protected void Application_Start()
        {
            Mvc.Setup();
            Unity.Setup();
            Ef4.Setup();
            Solr.Setup();
        }
    }
}