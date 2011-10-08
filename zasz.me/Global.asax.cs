using System.Web;
using zasz.me.Integration;
using zasz.me.Integration.EntityFramework;
using zasz.me.Integration.MVC;
using zasz.me.Integration.SolrIntegration;

namespace zasz.me
{
    public class ZaszDotMe : HttpApplication
    {
        protected void Application_Start()
        {
            MvcIntegration.Bootstrap();
            UnityIntegration.Bootstrap();
            Ef4Integration.Bootstrap();
            SolrIntegration.Bootstrap();
        }
    }
}