using Xunit;
using zasz.me.Services.Concrete;

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
        public void MySoAnswersConstructsUrlForMyStackOverflowAnswers()
        {
            Assert.Equal("http://api.stackexchange.com/users/626084/answers?site=stackoverflow&key=usSGUdqhSFinjmEGnQYRCg((", 
                stackUrls.MySoAnswers);
        }

        [Fact]
        public void MySoAnswersIsAUrlForMyStackOverflowQuestions()
        {
            Assert.Equal("http://api.stackexchange.com/users/626084/questions?site=stackoverflow&key=usSGUdqhSFinjmEGnQYRCg((",
                stackUrls.MySoAnswers);
        }

        [Fact]
        public void SoQuestionGetsTheTitleForGivenQuestions()
        {
            Assert.Equal("http://api.stackexchange.com/questions/11794084;35026;15841?site=stackoverflow&key=usSGUdqhSFinjmEGnQYRCg((",
                stackUrls.SoQuestion("11794084;35026;15841"));
        }
    }
}