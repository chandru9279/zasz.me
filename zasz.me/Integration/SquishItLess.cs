using zasz.me.Integration;

[assembly: WebActivator.PreApplicationStartMethod(typeof(SquishItLess), "Start")]
namespace zasz.me.Integration
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