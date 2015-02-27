[assembly: WebActivator.PreApplicationStartMethod(typeof(zasz.me.SquishItLess), "Start")]
namespace zasz.me
{
    using SquishIt.Framework;
    using SquishIt.Less;

    using zasz.me.Annotations;

    public class SquishItLess
    {
        [UsedImplicitly]
        public static void Start()
        {
            Bundle.RegisterStylePreprocessor(new LessPreprocessor());
        }
    }
}