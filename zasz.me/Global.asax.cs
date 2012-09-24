using System.Web;
using zasz.me.Integration.EntityFramework;
using zasz.me.Integration.MVC;
using zasz.me.Integration.Solr;

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