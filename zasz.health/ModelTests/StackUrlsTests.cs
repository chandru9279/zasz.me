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
        public void MyStackOverflowAnswersConstructsUrlForMyStackOverflowAnswers()
        {
            Assert.Equal("http://api.stackexchange.com/users/626084/answers?site=stackoverflow&sort=votes&page=1&key=usSGUdqhSFinjmEGnQYRCg((", 
                stackUrls.MyStackOverflowAnswers(1));
        }

        [Fact]
        public void MyStackOverflowAnswersIsAUrlForMyStackOverflowQuestions()
        {
            Assert.Equal("http://api.stackexchange.com/users/626084/questions?site=stackoverflow&sort=votes&page=1&key=usSGUdqhSFinjmEGnQYRCg((",
                stackUrls.MyStackOverflowQuestions(1));
        }

        [Fact]
        public void StackOverflowQuestionGetsTheTitleForGivenQuestions()
        {
            Assert.Equal("http://api.stackexchange.com/questions/11794084;35026;15841?site=stackoverflow&key=usSGUdqhSFinjmEGnQYRCg((",
                stackUrls.StackOverflowQuestion("11794084;35026;15841"));
        }
    }
}