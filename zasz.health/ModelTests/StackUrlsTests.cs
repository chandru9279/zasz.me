using Xunit;
using zasz.me.Models;

namespace zasz.health.ModelTests
{
    public class StackUrlsTests
    {
        private readonly StackUrls stackUrls;

        public StackUrlsTests()
        {
            stackUrls = new StackUrls();
        }

        [Fact]
        public void ShouldGetUrlForMyStackOverflowAnswers()
        {
            Assert.Equal("http://api.stackexchange.com/users/626084/answers?site=stackoverflow&key=usSGUdqhSFinjmEGnQYRCg((", 
                stackUrls.MySoAnswers);
        }

        [Fact]
        public void ShouldGetUrlForMyStackOverflowQuestions()
        {
            Assert.Equal("http://api.stackexchange.com/users/626084/questions?site=stackoverflow&key=usSGUdqhSFinjmEGnQYRCg((", 
                stackUrls.MySoQuestions);
        }

        [Fact]
        public void ShouldGetTitleForGivenQuestions()
        {
            Assert.Equal("http://api.stackexchange.com/questions/11794084;35026;15841?site=stackoverflow&key=usSGUdqhSFinjmEGnQYRCg((",
                stackUrls.SoQuestion("11794084;35026;15841"));
        }
    }
}