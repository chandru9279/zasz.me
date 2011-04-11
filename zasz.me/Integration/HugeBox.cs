using Microsoft.Practices.Unity;
using Raven.Client;

namespace zasz.me.Integration
{
    public class HugeBox
    {
        private static UnityContainer _BigBox;

        public static UnityContainer BigBox
        {
            get { return _BigBox; }
        }

        public static void Swallow(UnityContainer TheBigBox)
        {
            _BigBox = TheBigBox;
        }

        /// <summary>
        ///     Puts the DocumentStore instance in the Unity Container. And sets up the Unity container
        ///     to create and give one document session per web request. (singleton session per webrequest,
        ///     using the HttpContext.Current)
        /// 
        ///     For registering factories, that helps unity build objects-
        ///     http://www.pnpguidance.net/post/RegisteringFactoryMethodCreateObjectsUnityStaticFactoryExtension.aspx
        ///     which is now obsolete - or so visual studio says. Further it tells me to use Injection
        /// 
        ///     For creating singleton per web request :
        /// </summary>
        /// <param name = "DocumentStore">The Raven Document Store</param>
        public static void Swallow(IDocumentStore DocumentStore)
        {
            _BigBox
                .RegisterInstance(DocumentStore) // Type automatically inferred
                .RegisterType<IDocumentSession>(
                    new SingletonPerRequest("Raven-Session"),
                    new InjectionFactory(Container => Container.Resolve<IDocumentStore>().OpenSession())
                );
        }

        public static T Grab<T>()
        {
            return _BigBox.Resolve<T>();
        }
    }
}