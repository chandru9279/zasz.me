using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Xunit;
using zasz.me.Integration.EntityFramework;
using zasz.me.Models;

namespace zasz.health.UtilityTests
{
    public class MaintainanceTests
    {
        private readonly FullContext fullContext;
        private readonly IPostRepository postRepository;
        private readonly ITagRepository tagRepository;

        public MaintainanceTests()
        {
            fullContext = new FullContext();
            tagRepository = new Tags(fullContext);
            postRepository = new Posts(fullContext);
        }

        [Fact(Skip = "Utility")]
        public void ImportLegacyPosts()
        {
            var path = TestX.RepoPath + @"\Database\Legacy\Posts";
            foreach (var newPost in new PostsImportExport(Log).GetFromFolder(path))
            {
                postRepository.Save(newPost);
            }
            postRepository.Commit();
        }

        [Fact(Skip = "Utility")]
        public void ExportPosts()
        {
            new PostsImportExport(Log).ExportToFolders(postRepository.Page(0, 100));
        }

        [Fact(Skip = "Utility")]
        public void ClearUnusedTags()
        {
            foreach (var tag in fullContext.Tags
                .Include("Posts")
                .Where(tag => tag.Posts.Count <= 0))
            {
                Log(tag.Name + " had no posts, and was deleted.");
                tagRepository.Delete(tag);
            }
            tagRepository.Commit();
            Log("Done");
        }

        [Fact(Skip = "Utility")]
        public void ClearErrorLogs()
        {
            fullContext.Database.ExecuteSqlCommand("DELETE FROM Logs");
            Log("Done.");
        }

        [Fact(Skip = "Utility")]
        public void HashPassword()
        {
            const string password = "CustomPasswordHere";
            var algorithm = new SHA256Cng();
            var unicoding = new UnicodeEncoding();
            var hash = unicoding.GetString(algorithm.ComputeHash(unicoding.GetBytes(password)));
            Log(hash);
        }

        private static void Log(string log)
        {
            Debug.WriteLine(log);
        }
    }
}