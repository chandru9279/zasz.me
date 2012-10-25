using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using HtmlAgilityPack;
using Xunit;
using zasz.me;
using zasz.me.Integration.EntityFramework;
using zasz.me.Models;
using zasz.me.Services.Concrete.PostPopulators;

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
            tagRepository = new TagRepository(fullContext);
            postRepository = new PostRepository(fullContext);
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
            new PostsImportExport(Log).ExportToFolders(postRepository.Page(0, 100).Set);
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
            fullContext.Database.ExecuteSqlCommand(string.Format("DELETE FROM {0}", DbConstants.Logs));
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

        [Fact(Skip = "Utility")]
        public void CommentsToWxr()
        {
            var path = TestX.RepoPath + @"\Database\Legacy\Posts";
            new CommentsExport().ExportToWxr(path);
            Log("Done");
        }

        [Fact]
        public void TargetBlankInAllPosts()
        {
            const string path = @"C:\Users\Hyperion\Google Drive\Posts";
            var postHtmls = Directory.GetDirectories(path)
                .Select(x => new DirectoryInfo(x))
                .Where(x => x.EnumerateDirectories().Any(y => y.Name == "PostContent"))
                .Select(x => x.GetFiles(TitleAndContentPopulator.ContentHtml))
                .Select(x => x.First());
            foreach (var post in postHtmls)
            {
                Debug.WriteLine(" -={0}=- ", (object)post.Name);
                ProcessPost(post);
            }
        }

        private static void ProcessPost(FileInfo post)
        {
            var doc = new HtmlDocument();
            using (var fileStream = post.OpenRead())
                doc.Load(fileStream);
            doc.ParseErrors.ForEach(x =>
                Debug.WriteLine("{0} : {1}\r\n{2}\r\n{3}\r\n{4}\r\n{5}\r\n",
                post.Name, x.Code, x.Line, x.LinePosition, x.Reason, x.SourceText));
            FixTarget(post, doc);
        }

        private static void FixTarget(FileInfo post, HtmlDocument doc)
        {
            var withoutTarget = doc.DocumentNode.SelectNodes("//a[not(@target)]");
            if (withoutTarget == null || !withoutTarget.Any()) return;
            foreach (var anchor in withoutTarget)
                anchor.Attributes.Add("target", "_blank");
            Debug.WriteLine("{0} : Fixed {1} links\r\n", post.Name, withoutTarget.Count);
            using (var fileStream = post.OpenWrite())
                doc.Save(fileStream);
        }

        private static void Log(string log)
        {
            Debug.WriteLine(log);
        }
    }
}