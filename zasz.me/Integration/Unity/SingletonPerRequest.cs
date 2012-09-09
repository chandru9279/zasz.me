using System;
using System.Web;
using Microsoft.Practices.Unity;

namespace zasz.me.Integration.Unity
{
    public class SingletonPerRequest : LifetimeManager, IDisposable
    {
        private readonly string name;

        public SingletonPerRequest(string name)
        {
            this.name = name;
        }

        #region IDisposable Members

        public void Dispose()
        {
            RemoveValue();
        }

        #endregion

        public override object GetValue()
        {
            return HttpContext.Current.Items[name];
        }

        public override void RemoveValue()
        {
            HttpContext.Current.Items.Remove(name);
        }

        public override void SetValue(object newValue)
        {
            HttpContext.Current.Items[name] = newValue;
        }
    }
}