[assembly: WebActivator.PreApplicationStartMethod(typeof(zasz.me.App_Start.SquishItLess), "Start")]

namespace zasz.me.App_Start
{
    using SquishIt.Framework;
    using SquishIt.Less;

    public class SquishItLess
    {
        public static void Start()
        {
            Bundle.RegisterStylePreprocessor(new LessPreprocessor());
        }
    }
}