using SolrNet;
using zasz.me.Areas.Shared.Models;

namespace zasz.me.Integration.SolrIntegration
{
    public class SolrIntegration
    {
        public static void Bootstrap()
        {
            Startup.Init<Post>("http://localhost:5000/solr");
        }
    }
}