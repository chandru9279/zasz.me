using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace zasz.me.Integration.Unity
{
    public class UnityDependencyResolver : IDependencyResolver
    {
        private readonly IUnityContainer container;

        public UnityDependencyResolver()
        {
            container = Big.Box;
        }

        #region IDependencyResolver Members

        public object GetService(Type serviceType)
        {
            if (!container.IsRegistered(serviceType))
            {
                if (serviceType.IsAbstract || serviceType.IsInterface)
                {
                    return null;
                }
            }
            return container.Resolve(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return container.ResolveAll(serviceType);
        }

        #endregion
    }
}