using System.IO;
using zasz.me.Models;

namespace zasz.me.Services.Contracts
{
    public interface IPostPopulator
    {
        void Populate(Post post, DirectoryInfo directory);
    }
}