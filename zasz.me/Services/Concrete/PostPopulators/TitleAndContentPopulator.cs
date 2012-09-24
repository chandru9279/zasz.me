using System.IO;
using System.Linq;
using zasz.me.Models;
using zasz.me.Services.Contracts;

namespace zasz.me.Services.Concrete.PostPopulators
{
    public class TitleAndContentPopulator : IPostPopulator
    {
        #region IPostPopulator Members

        public void Populate(Post post, DirectoryInfo directory)
        {
            var fileInfos = directory.GetFiles("*.html");
            var content = fileInfos.First();
            post.Title = content.Name;
            post.Content = new StreamReader(content.OpenRead()).ReadToEnd();
        }

        #endregion
    }
}