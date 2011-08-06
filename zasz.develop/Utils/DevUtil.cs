using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using zasz.develop.SampleData;
using zasz.me.Areas.Shared.Models;
using zasz.me.Integration.EntityFramework;
using zasz.me.Integration.Lucene;
using Domain = zasz.me.Areas.Shared.Models.Site;

namespace zasz.develop.Utils
{
    public partial class DevUtil : Form
    {
        private readonly ChooseSite _ChooseSiteDialog;
        private readonly FullContext _FullContext;
        private readonly IPostRepository _PostRepository;
        private readonly ITagRepository _TagRepository;


        public DevUtil()
        {
            InitializeComponent();
            _ChooseSiteDialog = new ChooseSite();
            //Database.SetInitializer(new ColdStorageInitializer());
            _FullContext = new FullContext();
            _TagRepository = new Tags(_FullContext);
            _PostRepository = new Posts(_FullContext);
        }

        public string Current { get; set; }


        private void ImportPostsClick(object Sender, EventArgs E)
        {
            try
            {
                string Path = Environment.GetEnvironmentVariable("ProjectRootPath") + @"\zasz.develop\SampleData\Posts";

                foreach (Post NewPost in PostsData.GetFromFolder(Path, Log))
                {
                    Current = NewPost.Title;
                    if (AllPro.Checked) NewPost.Site = Domain.Pro;
                    else if (AllBoth.Checked) NewPost.Site = Domain.Shared;
                    else if (AllRest.Checked) NewPost.Site = Domain.Rest;
                    else if (Default.Checked)
                    {
                        NewPost.Site = Domain.With(PostsData.DefaultSiteMap[NewPost.Slug]);
                    }
                    else
                    {
                        DialogResult Dialog = _ChooseSiteDialog.ShowDialog(this);
                        if (Dialog == DialogResult.Cancel) Die("You cancelled");
                        NewPost.Site = Domain.With(ChooseSite.MapSites[Dialog]);
                    }
                    _PostRepository.Save(NewPost);
                }

                _PostRepository.Commit();
            }
            catch (Death)
            {
            }
        }

        private void Die(String DieLog)
        {
            Log(DieLog);
            throw new Death(DieLog);
        }

        private void Log(string Log, params object[] Args)
        {
            this.Log(string.Format(Log, Args));
        }

        private void Log(string Log)
        {
            DevConsole.Text = DevConsole.Text + Environment.NewLine + Log;
        }

        private void ClearConsoleClick(object Sender, EventArgs E)
        {
            DevConsole.Clear();
        }

        private void ClearColdStorageClick(object Sender, EventArgs E)
        {
            DeleteByType<Post>();
            Log("Done");
        }

        private void DeleteByType<T>() where T : class
        {
            Log("Deleting All {0} from ColdStorage.. ", typeof (T));
            foreach (T Model in _FullContext.Set<T>())
                _FullContext.Set<T>().Remove(Model);
            _FullContext.SaveChanges();
            Log("Done (All {0} Deleted from ColdStorage..) !", typeof (T));
            Log("Done");
        }

        private void ClearPostContentClick(object Sender, EventArgs E)
        {
            List<Post> Posts = _PostRepository.Page(0, 100);
            foreach (Post Post in Posts)
                Post.Content = "Content";
            _PostRepository.Commit();
            Log("Done");
        }

        private void CommentsToWxrClick(object Sender, EventArgs E)
        {
            string Path = Environment.GetEnvironmentVariable("SampleDataPath");
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
            foreach (Tag TheTag in _FullContext.Tags.Include("Posts"))
            {
                if (TheTag.Posts.Count <= 0)
                {
                    Log(TheTag.Name + " had no posts, and was deleted.");
                    _TagRepository.Delete(TheTag);
                }
            }
            _TagRepository.Commit();
            Log("Done");
        }

        private void ChangeSiteNameClick(object Sender, EventArgs E)
        {
            List<Post> Posts = _PostRepository.Page(0, 100);
            Posts.ForEach(ChangeSite);
            _PostRepository.Commit();
            Log("Done");
        }

        private static void ChangeSite(Post Entry)
        {
            if (Entry.Site.Name == "Both")
                //Entry.Site = Domain.Shared;
                throw new Exception("Both still exists! : " + Entry.Title);
        }

        private void ClearErrorLogsClick(object Sender, EventArgs E)
        {
            _FullContext.Database.ExecuteSqlCommand("DELETE FROM Logs");
            Log("Done.");
        }

        private void HashPasswordClick(object Sender, EventArgs E)
        {
            if (string.IsNullOrEmpty(Password.Text))
            {
                Log("Password Empty");
                return;
            }
            var Algorithm = new SHA256Cng();
            var Unicoding = new UnicodeEncoding();
            PassHash.Text = Unicoding.GetString(Algorithm.ComputeHash(Unicoding.GetBytes(Password.Text)));
        }

        private void RebuildLuceneClick(object Sender, EventArgs E)
        {
            
        }
    }
}