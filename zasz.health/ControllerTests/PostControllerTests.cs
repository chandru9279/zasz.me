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
    }
}    