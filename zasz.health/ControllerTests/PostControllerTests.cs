using System;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using zasz.me.Areas.Pro.Controllers;
using zasz.me.Controllers;
using zasz.me.Models;

namespace zasz.health.ControllerTests
{
    [TestClass]
    public class PostControllerTests
    {
        private readonly PostController _Controller;

        private readonly Mock<IPostRepository> _PostRepository;

        public PostControllerTests()
        {
            _PostRepository = new Mock<IPostRepository>();
            _Controller = new WritingsController(_PostRepository.Object);
        }

        [TestMethod]
        public void TestSlugger()
        {
            Func<string, string> Try = PostController.GetSlug;
            Assert.AreEqual("detail-id-equals-2190", Try("detail?id=2190"));
            Assert.AreEqual("func-percent-20-gnome", Try("func%20&nbsp;gnome"));
            Assert.AreEqual("c-sharp-rocks", Try("C# Rocks!"));
            Assert.AreEqual("using-di-or-dependency-injection", Try(HttpUtility.HtmlEncode("using DI/Dependency Injection")));
            Assert.AreEqual("using-di-or-dependency-injection", Try("using DI/Dependency Injection"));
        }

        [TestMethod]
        public void One()
        {
            const string ID = "49105961189491232322";
            var Actual = Captcha(ID);
            Assert.AreEqual("1dVgJB", Actual);
        }

        [TestMethod]
        public void Two()
        {
            const string Id = "6612111411369135233323";
            var Actual = Captcha(Id);
            Assert.AreEqual("1dVgJB", Actual);
        }

        private string Captcha(string ID)
        {
            var Substring = ID.Substring(ID.Length - 6, 6);
            var Result = "";
            for (int i = 0, startIndex = 0; i < 6; i++)
            {
                var CurrentLength = int.Parse(Substring[i].ToString());
                int ASCII = int.Parse(ID.Substring(startIndex, CurrentLength)) - i * 5;
                Result += Convert.ToChar(ASCII);
                startIndex += CurrentLength;
            }
            return Result;
        }
    }
}