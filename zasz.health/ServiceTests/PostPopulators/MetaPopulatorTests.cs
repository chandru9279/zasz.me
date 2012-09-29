using System;
using System.IO;
using Xunit;
using zasz.me;
using zasz.me.Services.Concrete.PostPopulators;

namespace zasz.health.ServiceTests.PostPopulators
{
    public class MetaPopulatorTests
    {
        private DirectoryInfo postPack;

        public MetaPopulatorTests()
        {
            postPack = new DirectoryInfo(Path.Combine(X.ProjectPath, "TestData/TestPost"));
        }
       
        [Fact]
        public void MetaPopulatorPopulatesTimestamp()
        {
            var dateTime = new MetaPopulator(null).GetTime("24-09-2012 21:44");
            var time = dateTime;
            Assert.Equal(24, time.Day);
            Assert.Equal(9, time.Month);
            Assert.Equal(2012, time.Year);
            Assert.Equal(21, time.Hour);
            Assert.Equal(44, time.Minute);
        }
    }
}