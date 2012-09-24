using System.IO;
using zasz.me.Models;
using zasz.me.Services.Contracts;

namespace zasz.me.Services.Concrete.PostPopulators
{
    public class PostValidator : IPostPopulator
    {
        #region IPostPopulator Members

        public void Populate(Post post, DirectoryInfo directory)
        {
            post.Validate();
        }

        #endregion
    }
}