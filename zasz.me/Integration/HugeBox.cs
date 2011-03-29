using Microsoft.Practices.Unity;
using Raven.Client;

namespace zasz.me.Integration
{
    public class HugeBox
    {
        private static UnityContainer _BigBox;

        public static void Swallow(UnityContainer BigBox)
        {
            _BigBox = BigBox;
        }

        public static void Swallow(IDocumentStore DocumentStore)
        {
            _BigBox.RegisterInstance(typeof(IDocumentStore), DocumentStore);
        }

        public static T Grab<T>()
        {
            return _BigBox.Resolve<T>();
        }
    }
}