using Xunit;
using zasz.health.UtilityTests;
using zasz.me.Integration.EntityFramework;

namespace zasz.health.RepositoryTests
{
    public class RepoBaseIntegrationTests : Fixture<PostAndTagsTestData>
    {
        private TagRepository tagRepository;
        private PostRepository postRepository;

        protected override void InitFixture()
        {
            tagRepository = new TagRepository(Context);
            postRepository = new PostRepository(Context);
        }

        [Fact]
        public void CountOfPostsIsThree()
        {
            var count = postRepository.Count();
            Assert.Equal(3, count);
        }

        [Fact]
        public void CountOfTagsIsAlsoThree()
        {
            var count = tagRepository.Count();
            Assert.Equal(3, count);
        }
    }
}