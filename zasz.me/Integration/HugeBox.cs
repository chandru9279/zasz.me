using Microsoft.Practices.Unity;
using Raven.Client.Document;

namespace zasz.me.Integration
{
    public class HugeBox
    {
        private static UnityContainer _BigBox;
        private static DocumentStore _DocumentStore;

        public static void Swallow(UnityContainer BigBox)
        {
            _BigBox = BigBox;
        }

        public static void Swallow(DocumentStore DocumentStore)
        {
            _DocumentStore = DocumentStore;
        }

        public static T Grab<T>()
        {
            return _BigBox.Resolve<T>();
        }
    }
}