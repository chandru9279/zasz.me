using Microsoft.Practices.Unity;

namespace zasz.me.Integration
{
    public class Big
    {
        public static UnityContainer Box { get; private set; }

        public static void Swallow(UnityContainer theBigBox)
        {
            Box = theBigBox;
        }
    }
}