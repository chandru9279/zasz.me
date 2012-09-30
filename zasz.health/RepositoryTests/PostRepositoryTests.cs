using Xunit;
using zasz.health.UtilityTests;
using zasz.me.Integration.EntityFramework;

namespace zasz.health.RepositoryTests
{
    public class PostRepositoryTests : Fixture<PostAndTagsTestData>
    {
        private PostRepository postRepository;
        private TagRepository tagRepository;

        protected override void InitFixture()
        {
            tagRepository = new TagRepository(Context);
            postRepository = new PostRepository(Context);
        }

        [Fact, TimeTaken]
        public void PagingShouldReturnListOfPostsPageByPageDescendingOrderOfTimestamp()
        {
            var page = postRepository.Page(0, 2);
            Assert.Equal(page.Count, 2);
            Assert.Equal(TestData.Third.Id, page[0].Id);
            Assert.Equal(TestData.Second.Id, page[1].Id);
            page = postRepository.Page(1, 2);
            Assert.Equal(page.Count, 1);
            Assert.Equal(TestData.First.Id, page[0].Id);
        }
    }
}