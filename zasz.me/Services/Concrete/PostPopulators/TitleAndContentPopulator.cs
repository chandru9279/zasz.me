using System.IO;
using System.Linq;
using zasz.me.Models;
using zasz.me.Services.Contracts;

namespace zasz.me.Services.Concrete.PostPopulators
{
    public class TitleAndContentPopulator : IPostPopulator
    {
        public const string ContentHtml = "*.html";

        #region IPostPopulator Members

        public void Populate(Post post, DirectoryInfo directory)
        {
            var fileInfos = directory.GetFiles(ContentHtml);
            var content = fileInfos.First();
            post.Title = content.Name.Replace(".html", string.Empty);
            post.Content = File.ReadAllText(content.FullName);
        }

        #endregion
    }
}