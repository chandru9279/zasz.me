using System;
using System.Windows.Forms;
using zasz.me.Services;

namespace zasz.develop.Utils
{
    public partial class ChooseSite : Form
    {
        public static Pairs<string, DialogResult> MapSites;

        public ChooseSite()
        {
            InitializeComponent();

            if (MapSites == null)
                MapSites = new Pairs<string, DialogResult>(
                    new[] {"Pro", "Rest", "Both"},
                    new[] {DialogResult.Ignore, DialogResult.Abort, DialogResult.Retry}
                    );
        }


        private void AnyClick(object sender, EventArgs e)
        {
            DialogResult = MapSites[((Button) sender).Text];
            Close();
        }

        private void ChooseSite_Load(object sender, EventArgs e)
        {
            Title.Text = ((DevUtil)Owner).Current;
        }
    }
}