using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using zasz.me.Services;

namespace zasz.develop.Utils
{
    public partial class TagCloud : Form
    {
        private Color _Bg = Color.White;
        private Color _Fg = Color.Black;
        private FontsService _Service;

        public TagCloud()
        {
            InitializeComponent();
        }

        private void GenerateClick(object Sender, EventArgs E)
        {
            string SystemPath = Environment.GetEnvironmentVariable("ProjectRootPath") +
                                @"\zasz.develop\SampleData\TagCloud";
            Dictionary<string, int> Tags = Words.Lines.Select(
                Line => Line.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries))
                .Where(Splits => Splits.Length == 2)
                .ToDictionary(Splits => Splits[0], Splits => int.Parse(Splits[1]));
            var TagCloudService = new TagCloudService(Tags)
                                      {
                                          MaximumFontSize = float.Parse(MaxFontSize.Text),
                                          MinimumFontSize = float.Parse(MinFontSize.Text),
                                      };
            if (!String.IsNullOrEmpty(Angle.Text)) TagCloudService.Angle = int.Parse(Angle.Text);
            if (null != FontsCombo.SelectedItem)
                TagCloudService.SelectedFont = _Service.AvailableFonts[FontsCombo.SelectedItem.ToString()];
            if (null != StrategyCombo.SelectedItem)
                TagCloudService.DisplayChoice = DisplayStrategy.Get(
                    (TagDisplayStrategy) Enum.Parse(typeof (TagDisplayStrategy), StrategyCombo.SelectedItem.ToString()));
            if (null != BgfgStrategyCombo.SelectedItem && null != FgStrategyCombo.SelectedItem)
            {
                TagCloudService.ColorChoice = ColorStrategy.Get(
                    (BackgroundForegroundScheme)
                    Enum.Parse(typeof (BackgroundForegroundScheme), BgfgStrategyCombo.SelectedItem.ToString()),
                    (ForegroundScheme) Enum.Parse(typeof (ForegroundScheme), FgStrategyCombo.SelectedItem.ToString()),
                    _Bg, _Fg);
            }


            Bitmap Bitmap = TagCloudService.Get(int.Parse(Width.Text), int.Parse(Height.Text));
            Bitmap.Save(SystemPath + @"\Cloud.png", ImageFormat.Png);
            Cloud.Image = Bitmap;
        }

        private void TagCloudLoad(object Sender, EventArgs E)
        {
            string SystemPath = Environment.GetEnvironmentVariable("ProjectRootPath") + @"\zasz.me\Content\Shared\Fonts";
            _Service = new FontsService();
            _Service.LoadFonts(SystemPath);
            FontsCombo.Items.AddRange(_Service.AvailableFonts.Keys.ToArray());
            StrategyCombo.Items.AddRange(Enum.GetNames(typeof (TagDisplayStrategy)));
            BgfgStrategyCombo.Items.AddRange(Enum.GetNames(typeof (BackgroundForegroundScheme)));
            FgStrategyCombo.Items.AddRange(Enum.GetNames(typeof (ForegroundScheme)));
        }

        private void SetBgClick(object Sender, EventArgs E)
        {
            if (ColorPick.ShowDialog() == DialogResult.OK)
            {
                _Bg = ColorPick.Color;
                BackG.BackColor = _Bg;
            }
        }

        private void SetFgClick(object Sender, EventArgs E)
        {
            if (ColorPick.ShowDialog() == DialogResult.OK)
            {
                _Fg = ColorPick.Color;
                ForeG.BackColor = _Fg;
            }
        }
    }
}