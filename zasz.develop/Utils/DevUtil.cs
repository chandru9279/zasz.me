using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Windows.Forms;
using zasz.develop.SampleData;
using zasz.me.Areas.Shared.Models;
using zasz.me.Integration.EntityFramework;
using My = zasz.me.Areas.Shared.Models;

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
            Database.SetInitializer(new ColdStorageInitializer());
            _FullContext = new FullContext();
            _TagRepository = new Tags(_FullContext);
            _PostRepository = new Posts(_FullContext, _TagRepository);
            PostsData.RegisterSites();
        }

        public string Current { get; set; }


        private void ImportPostsClick(object Sender, EventArgs E)
        {
            try
            {
                string Path = Environment.GetEnvironmentVariable("SampleDataPath");

                foreach (Post NewPost in PostsData.GetFromFolder(Path, Log))
                {
                    Current = NewPost.Title;
                    if (AllPro.Checked) NewPost.Site = My.Site.WithName("Pro");
                    else if (AllBoth.Checked) NewPost.Site = My.Site.WithName("Both");
                    else if (AllRest.Checked) NewPost.Site = My.Site.WithName("Rest");
                    else if (Default.Checked)
                    {
                        NewPost.Site = My.Site.WithName(PostsData.DefaultSiteMap[NewPost.Slug]);
                    }
                    else
                    {
                        DialogResult Dialog = _ChooseSiteDialog.ShowDialog(this);
                        if (Dialog == DialogResult.Cancel) Die("You cancelled");
                        NewPost.Site = My.Site.WithName(ChooseSite.MapSites[Dialog]);
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
        }

        private void DeleteByType<T>() where T : class
        {
            Log("Deleting All {0} from ColdStorage.. ", typeof(T));
            foreach (T Model in _FullContext.Set<T>())
                _FullContext.Set<T>().Remove(Model);
            _FullContext.SaveChanges();
            Log("Done (All {0} Deleted from ColdStorage..) !", typeof(T));
        }

        /*
         * Converts tags like
         * <img src="/ThonHttpHandlers/Image.ashx?picturepath=~/App_Data/ZaszBlog/Files\Image328.jpg" alt="" width="60%" height="60%">
         * to 
         * <img src="/ThonHttpHandlers/Image.ashx?picturepath=~/App_Data/ZaszBlog/Files\Image328.jpg" alt="" width="60%" height="60%">
         */

        private void ClearPostContentClick(object Sender, EventArgs E)
        {
            List<Post> Posts = _PostRepository.Page(0, 100);
            foreach (Post Post in Posts)
                Post.Content = "Content";
            _PostRepository.Commit();
        }

        private void CommentsToWxrClick(object Sender, EventArgs E)
        {
            string Path = Environment.GetEnvironmentVariable("SampleDataPath");
            new CommentsExport {CommentsProgress = CommentsProgress, SpamAmount = SpamAmount}.ConvertComments(Path, Log);
        }

        private void ShowTagCloud_Click(object sender, EventArgs e)
        {
            new TagCloud().Show();
        }

//        private void ProcessPostsClick(object Sender, EventArgs E)
//        {
//            var AllPosts = _PostRepository.Page(0, 50, My.Site.WithName("Both"));
//            foreach(Post It in AllPosts)
//            {
//                HtmlDocument Node = new HtmlDocument();
//                Node.LoadHtml(It.Content);
//                var ImageNodes = Node.DocumentNode.SelectNodes("//img");
//            }
//        }
    }
}

