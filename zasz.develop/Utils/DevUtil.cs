using System;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using zasz.develop.Data;
using zasz.me.Integration.EntityFramework;
using zasz.me.Models;

namespace zasz.develop.Utils
{
    public partial class DevUtil : Form
    {
        private readonly FullContext fullContext;
        private readonly IPostRepository postRepository;
        private readonly ITagRepository tagRepository;

        public DevUtil()
        {
            InitializeComponent();
            fullContext = new FullContext();
            tagRepository = new Tags(fullContext);
            postRepository = new Posts(fullContext);
        }

        public string Current { get; set; }


        private void ImportPostsClick(object Sender, EventArgs E)
        {
            try
            {
                var path = ConfigurationManager.AppSettings["ProjectRootPath"] + @"\Database\Legacy\Posts";
                foreach (var newPost in PostsData.GetFromFolder(path, Log))
                {
                    postRepository.Save(newPost);
                }
                postRepository.Commit();
            }
            catch (Death)
            {
            }
        }

        private void Log(string log, params object[] args)
        {
            Log(string.Format(log, args));
        }

        private void Log(string log)
        {
            DevConsole.Text = DevConsole.Text + Environment.NewLine + log;
        }

        private void ClearConsoleClick(object Sender, EventArgs E)
        {
            DevConsole.Clear();
        }

        private void CommentsToWxrClick(object Sender, EventArgs E)
        {
            var Path = ConfigurationManager.AppSettings["ProjectRootPath"] + @"\Data-Tools-Setup\Posts";
            new CommentsExport {CommentsProgress = CommentsProgress, SpamAmount = SpamAmount}.ConvertComments(Path, Log);
            Log("Done");
        }

        // ReSharper disable MemberCanBeMadeStatic.Local
        private void ShowTagCloudClick(object Sender, EventArgs E)
        {
            new TagCloud().Show();
            Log("Done");
        }

        // ReSharper restore MemberCanBeMadeStatic.Local

        private void ClearUnusedTagsClick(object Sender, EventArgs E)
        {
            foreach (var TheTag in fullContext.Tags
                .Include("Posts")
                .Where(TheTag => TheTag.Posts.Count <= 0))
            {
                Log(TheTag.Name + " had no posts, and was deleted.");
                tagRepository.Delete(TheTag);
            }
            tagRepository.Commit();
            Log("Done");
        }

        private void ClearErrorLogsClick(object Sender, EventArgs E)
        {
            fullContext.Database.ExecuteSqlCommand("DELETE FROM Logs");
            Log("Done.");
        }

        private void HashPasswordClick(object Sender, EventArgs E)
        {
            if (string.IsNullOrEmpty(Password.Text))
            {
                Log("Password Empty");
                return;
            }
            var algorithm = new SHA256Cng();
            var unicoding = new UnicodeEncoding();
            PassHash.Text = unicoding.GetString(algorithm.ComputeHash(unicoding.GetBytes(Password.Text)));
        }
    }
}