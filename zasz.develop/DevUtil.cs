using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Windows.Forms;
using System.Xml;
using Raven.Client.Document;
using zasz.me.Integration.RavenDB;
using zasz.me.Models;

namespace zasz.develop
{
    public partial class DevUtil : Form
    {
        private static DocumentStore _DocumentStore;
        private readonly ChooseSite _ChooseSiteDialog;
        private readonly IPostRepository _PostRepository;

        public DevUtil()
        {
            InitializeComponent();
            _ChooseSiteDialog = new ChooseSite();
            UseRavenDB();
            _PostRepository = new Posts(_DocumentStore);
            RegisterSites();
        }

        public string Current { get; set; }

        private static void RegisterSites()
        {
            me.Models.Site.Register("zasz.me", "Rest");
            me.Models.Site.Register("AnyHost", "Admin", "~/Home/Show");
            me.Models.Site.Register("AnyHost", "Both", "~/Home/Show");
            me.Models.Site.Register("chandruon.net", "Pro");
            me.Models.Site.Register("localhost", "Pro");
        }

        private void ImportPostsClick(object sender, EventArgs e)
        {
            try
            {
                DialogResult Result = UtilChooseFolder.ShowDialog();
                if (Result != DialogResult.OK)
                    Die("Could not get a source folder");
                string Path = String.IsNullOrEmpty(UtilChooseFolder.SelectedPath) ? @"C:\Documents and Settings\thiagac\My Documents\Visual Studio 2010\Projects\Posts" : UtilChooseFolder.SelectedPath;
                string[] Files = Directory.GetFiles(Path);
                var XmlFiles = from AFile in Files
                               where AFile.EndsWith(".xml")
                               select AFile;

                if (XmlFiles.Count() == 0)
                    Die("No XML Files found");

                foreach (string PostFile in XmlFiles)
                {
                    Log("Working on file : " + PostFile);
                    Post Post = new Post();
                    XmlDocument PostDoc = new XmlDocument();
                    PostDoc.Load(PostFile);
                    Post.Title = PostDoc.SelectSingleNode("post/title").InnerText;
                    Current = Post.Title;
                    Log("Title : " + Post.Title);
                    Post.Content = HttpUtility.HtmlDecode(PostDoc.SelectSingleNode("post/content").InnerText);
                    Post.Timestamp = DateTime.Parse(PostDoc.SelectSingleNode("post/pubDate").InnerText);
                    Post.Slug = PostDoc.SelectSingleNode("post/slug").InnerText;
                    foreach (XmlNode node in PostDoc.SelectNodes("post/tags/tag"))
                    {
                        if (!string.IsNullOrEmpty(node.InnerText))
                            Post.Tags.Add(node.InnerText);
                    }

                    DialogResult Dialog = _ChooseSiteDialog.ShowDialog(this);
                    if (Dialog == DialogResult.Cancel) Die("You cancelled");
                    Post.Site = me.Models.Site.WithName(ChooseSite.MapSites[Dialog]);
                    _PostRepository.Save(Post);
                }
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

        private void Log(string Log)
        {
            DevConsole.Text = DevConsole.Text + Environment.NewLine + Log;
        }

        private void ClearConsoleClick(object sender, EventArgs e)
        {
            DevConsole.Clear();
        }

        private static void UseRavenDB()
        {
            _DocumentStore = new DocumentStore {Url = "http://localhost:3000", DefaultDatabase = "ZaszStore"};
            _DocumentStore.Initialize();
            _DocumentStore.Conventions.FindIdentityProperty =
                Property =>
                    {
                        var IdAttributes = Property.GetCustomAttributes(typeof (IDAttribute), false) as IDAttribute[];
                        return IdAttributes != null && IdAttributes.Length > 0;
                    };
        }

        private void ClearDB_Click(object sender, EventArgs e)
        {
            Log("Deleting All Posts.. ");
            using(var Session = _DocumentStore.OpenSession())
            {
                Session.Query<Post>().ToList().ForEach(Session.Delete);
                Session.SaveChanges();
            }
            Log("Done (All Posts Deleted) !");
        }
    }
}

