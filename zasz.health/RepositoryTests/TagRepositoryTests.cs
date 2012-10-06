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
        public void WeightedListGivesTagsAndSizes()
        {
        }
    }
}