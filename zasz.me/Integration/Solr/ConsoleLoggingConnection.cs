using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SolrNet;
using SolrNet.Impl;

namespace zasz.me.Integration.Solr
{
    // This class kicks in when <compilation debg="true" />
    public class ConsoleLoggingConnection : ISolrConnection
    {
        private readonly ISolrConnection connection;

        public ConsoleLoggingConnection(string url)
        {
            connection = new SolrConnection(url);
        }

        #region ISolrConnection Members

        public string Post(string relativeUrl, string posted)
        {
            Debug.WriteLine("POST '{0}' to '{1}'", posted, relativeUrl);
            return connection.Post(relativeUrl, posted);
        }

        public string Get(string relativeUrl, IEnumerable<KeyValuePair<string, string>> parameters)
        {
            var keyValuePairs = parameters.ToList();
            var array = keyValuePairs.Select(x => String.Format("{0}={1}", x.Key, x.Value)).ToArray();
            Debug.WriteLine("GET '{0}' from '{1}'", String.Join(", ", array), relativeUrl);
            return connection.Get(relativeUrl, keyValuePairs);
        }

        #endregion
    }
}