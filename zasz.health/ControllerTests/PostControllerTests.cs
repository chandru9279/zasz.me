using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using zasz.me.Controllers;
using zasz.me.Models;

namespace zasz.health
{
    [TestClass]
    public class PostControllerTests
    {
        private readonly PostController _Controller;

        private readonly Mock<IPostRepository> _PostRepository;

        public PostControllerTests()
        {
            _PostRepository = new Mock<IPostRepository>();
            _Controller = new PostController(_PostRepository.Object);
        }

        [TestMethod]
        public void TestMoq()
        {
            _PostRepository.Setup(Repo => Repo.FromSlug("example-slug")).Returns(new Post {Title = "Example Post!"});
            Assert.AreEqual("Example Post!", _PostRepository.Object.FromSlug("example-slug").Title);
            _Controller.GetSlug("zzz");
        }
    }
}    