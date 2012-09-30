using Xunit;
using zasz.health.UtilityTests;
using zasz.me.Integration.EntityFramework;

namespace zasz.health.RepositoryTests
{
    public class TagRepositoryTests : Fixture<PostAndTagsTestData>
    {
        private TagRepository tagRepository;

        protected override void InitFixture()
        {
            tagRepository = new TagRepository(Context);
        }

        [Fact]
        public void TagOneShouldFetchFirstAndSecondPost()
        {
            var page = tagRepository.PagePosts("tag1", 0, 100);
            Assert.Equal(2, page.Count);
            Assert.Equal(TestData.Third.Id, page[0].Id);
            Assert.Equal(TestData.First.Id, page[1].Id);
        }
        
        [Fact]
        public void TagTwoShouldFetchSecondAndThirdPost()
        {
            var page = tagRepository.PagePosts("tag2", 0, 100);
            Assert.Equal(2, page.Count);
            Assert.Equal(TestData.Second.Id, page[0].Id);
            Assert.Equal(TestData.First.Id, page[1].Id);
        }

        [Fact]
        public void TagThreeShouldFetchFirstAndThirdPostWithPageSizeLimits()
        {
            var page = tagRepository.PagePosts("tag3", 0, 1);
            Assert.Equal(1, page.Count);
            Assert.Equal(TestData.Third.Id, page[0].Id);

            page = tagRepository.PagePosts("tag3", 1, 1);
            Assert.Equal(1, page.Count);
            Assert.Equal(TestData.Second.Id, page[0].Id);
        }
    }
}