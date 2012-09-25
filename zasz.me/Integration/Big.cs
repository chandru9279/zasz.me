using Autofac;

namespace zasz.me.Integration
{
    public class Big
    {
        public static IContainer Box { get; private set; }

        public static void Swallow(IContainer theBigBox)
        {
            Box = theBigBox;
        }
    }
}