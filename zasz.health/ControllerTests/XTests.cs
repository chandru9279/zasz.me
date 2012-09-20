using Xunit;
using zasz.me;

namespace zasz.health.ControllerTests
{
    public class XTests
    {
        [Fact]
        public void NameReturnsTheNameOfThePropertyUsedInTheExpression()
        {
            Assert.Equal(X.Name(x => x.Id), "Id");
            Assert.Equal(X.Name(x => x.Content), "Content");
        } 
        [Fact]
        public void PropertyInfoReturnsThePropertyInfoOfThePropertyUsedInTheExpression()
        {
            Assert.Equal(X.PropertyInfo(x => x.Content).Name, "Content");
        } 
    }
}