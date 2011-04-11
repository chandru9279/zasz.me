using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Raven.Client.Document;
using Raven.Client.Indexes;
using zasz.develop.SampleData;
using zasz.me.Integration.RavenDB;
using zasz.me.Integration.RavenDB.Indexes;
using zasz.me.Models;

namespace zasz.develop.Utils
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
            _PostRepository = new Posts(_DocumentStore.OpenSession());
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
                string PreselectedPath = UtilChooseFolder.SelectedPath;
                UtilChooseFolder.ShowDialog();
                string Path = String.IsNullOrEmpty(UtilChooseFolder.SelectedPath) ? PreselectedPath : UtilChooseFolder.SelectedPath;

                foreach (Post NewPost in PostsData.GetFromFolder(Path, Log))
                {
                    Current = NewPost.Title;
                    if (AllPro.Checked) NewPost.Site = me.Models.Site.WithName("Pro");
                    else if (AllBoth.Checked) NewPost.Site = me.Models.Site.WithName("Both");
                    else if (AllRest.Checked) NewPost.Site = me.Models.Site.WithName("Rest");
                    else
                    {
                        DialogResult Dialog = _ChooseSiteDialog.ShowDialog(this);
                        if (Dialog == DialogResult.Cancel) Die("You cancelled");
                        NewPost.Site = me.Models.Site.WithName(ChooseSite.MapSites[Dialog]);
                    }
                    _PostRepository.Save(NewPost);
                }

                _PostRepository.Flush();
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
            IndexCreation.CreateIndexes(typeof (Post_BySlug).Assembly, _DocumentStore);
            _DocumentStore.Conventions.FindIdentityProperty = RavenIntegration._FindIdentityProperty;
        }

        private void ClearDB_Click(object sender, EventArgs e)
        {
            try
            {
                Log("Deleting All Posts.. ");
                using (var Session = _DocumentStore.OpenSession())
                {
                    List<Post> Posts = Session.Query<Post>().ToList();
                    if (Posts.Count == 0) Die("Query returned 0 results");
                    Posts.ForEach(Session.Delete);
                    Session.SaveChanges();
                }
                Log("Done (All Posts Deleted) !");
            }
            catch (Death)
            {
            }
        }
    }
}