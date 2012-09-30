using System.Diagnostics;
using System.Reflection;
using Xunit;

namespace zasz.health.UtilityTests
{
    public class TimeTaken : BeforeAfterTestAttribute
    {
        private readonly Stopwatch watch = new Stopwatch();
        public override void Before(MethodInfo methodUnderTest)
        {
            watch.Start();
        }

        public override void After(MethodInfo methodUnderTest)
        {
            Debug.WriteLine(
                    "{0}.{1} : {2}",
                    methodUnderTest.DeclaringType.FullName,
                    methodUnderTest.Name,
                    watch.ElapsedMilliseconds / 1000
                    );
            watch.Stop();
        }
    }
}