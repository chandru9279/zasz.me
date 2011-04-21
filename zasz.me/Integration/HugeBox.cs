using Microsoft.Practices.Unity;

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

        public static T Grab<T>()
        {
            return _BigBox.Resolve<T>();
        }
    }
}