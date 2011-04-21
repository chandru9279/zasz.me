using System;
using System.Data.Entity;
using System.Windows.Forms;
using zasz.develop.SampleData;
using zasz.me.Integration.EntityFramework;
using zasz.me.Models;

namespace zasz.develop.Utils
{
    public partial class DevUtil : Form
    {
        private readonly ChooseSite _ChooseSiteDialog;
        private readonly FullContext _FullContext;
        private readonly IPostRepository _PostRepository;

        public DevUtil()
        {
            InitializeComponent();
            _ChooseSiteDialog = new ChooseSite();
            Database.SetInitializer(new ColdStorageInitializer());
            _FullContext = new FullContext();
            _PostRepository = new Posts(_FullContext);
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

        private void ClearConsoleClick(object sender, EventArgs e)
        {
            DevConsole.Clear();
        }

        private void ClearColdStorage_Click(object sender, EventArgs e)
        {
            DeleteByType<Post>();
        }

        private void DeleteByType<T>() where T : class
        {
            Log("Deleting All {0} from ColdStorage.. ", typeof(T));
            foreach (T Model in _FullContext.Set<T>())
                _FullContext.Set<T>().Remove(Model);
            Log("Done (All {0} Deleted from ColdStorage..) !", typeof(T));
        }
    }
}