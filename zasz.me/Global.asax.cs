using System.Web;
using zasz.me.Integration;
using zasz.me.Integration.EntityFramework;
using zasz.me.Integration.MVC;
using zasz.me.Integration.Solr;

namespace zasz.me
{
    public class ZaszDotMe : HttpApplication
    {
        protected void Application_Start()
        {
            AutoFac.Setup();
            Ef4.Setup();
            Mvc.Setup();
            Solr.Setup();
        }
    }
}