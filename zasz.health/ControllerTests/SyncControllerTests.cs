using System.IO;
using zasz.me;

namespace zasz.health.ControllerTests
{
    public class SyncControllerTests
    {
        private DirectoryInfo postPack;

        public SyncControllerTests()
        {
            postPack = new DirectoryInfo(Path.Combine(X.ProjectPath, "TestData/TestPost"));
        }
    }
}