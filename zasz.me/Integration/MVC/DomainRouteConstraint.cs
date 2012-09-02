using System;
using System.Web;
using System.Web.Routing;

namespace zasz.me.Integration.MVC
{
    public class DomainRouteConstraint : IRouteConstraint
    {
        private readonly string _Domain;

        public DomainRouteConstraint(string Domain)
        {
            _Domain = Domain;
        }

        #region IRouteConstraint Members

        public bool Match(HttpContextBase Context, Route Route, string ParameterName, RouteValueDictionary Values, RouteDirection RouteDirection)
        {
            var Url = Context.Request.Url.Host;
            return Url.Equals(_Domain, StringComparison.InvariantCultureIgnoreCase);
        }

        #endregion
    }
}