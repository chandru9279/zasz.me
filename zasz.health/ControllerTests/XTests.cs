using System.IO;
using Xunit;
using zasz.me;
using zasz.me.Models;

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
        
        [Fact]
        public void ProjectPathGivesThePathToTheProjectRoot()
        {
            var directoryInfo = new DirectoryInfo(X.ProjectPath);
            Assert.True(directoryInfo.Exists);
            Assert.Equal(1, directoryInfo.GetFiles("*.csproj").Length);
        }

        [Fact]
        public void TableAndSchemaNameGivesTheCorrectMappings()
        {
            Assert.Equal("[Blog].[Posts]", X.FullTableName<Post>());
        }
    }
}