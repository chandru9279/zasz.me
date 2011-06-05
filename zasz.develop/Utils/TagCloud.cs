using System;
using System.Collections.Generic;
using System.Windows.Forms;
using zasz.me.Services;

namespace zasz.develop.Utils
{
    public partial class TagCloud : Form
    {
        public TagCloud()
        {
            InitializeComponent();
        }

        private void GenerateClick(object Sender, EventArgs E)
        {
            Cloud.Image = new TagCloudService(new Dictionary<string, int>
                                                  {
                                                      {"asp.net", 15},
                                                      {"games", 10},
                                                      {"fun", 18},
                                                      {"books", 5},
                                                      {"music", 9},
                                                      {"crapo", 1},
                                                      {"dota", 2},
                                                  }).Get(300, 300);
        }
    }
}