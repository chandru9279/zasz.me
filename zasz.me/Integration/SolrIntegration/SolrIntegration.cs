using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SolrNet;
using SolrNet.Impl;
using zasz.me.Models;

namespace zasz.me.Integration.SolrIntegration
{
    public class SolrIntegration
    {
        public static void Bootstrap(bool Log)
        {
            if (Log)
                Startup.Init<Post>(new ConsoleLoggingConnection("http://localhost:5000/solr"));
            else
                Startup.Init<Post>("http://localhost:5000/solr");
        }

        public class ConsoleLoggingConnection : ISolrConnection
        {
            private readonly ISolrConnection _Connection;

            public ConsoleLoggingConnection(string Url)
            {
                _Connection = new SolrConnection(Url);
            }

            public string Post(string RelativeUrl, string Posted)
            {
                Debug.WriteLine("POSTing '{0}' to '{1}'", Posted, RelativeUrl);
                return _Connection.Post(RelativeUrl, Posted);
            }

            public string Get(string RelativeUrl, IEnumerable<KeyValuePair<string, string>> Parameters)
            {
                var StringParams = string.Join(", ", Parameters.Select(P => string.Format("{0}={1}", P.Key, P.Value)).ToArray());
                Debug.WriteLine("GETting '{0}' from '{1}'", StringParams, RelativeUrl);
                return _Connection.Get(RelativeUrl, Parameters);
            }
        }
    }
}