using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using zasz.me.Services.TagCloud;

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

        private void TagCloudLoad(object Sender, EventArgs E)
        {
            string SystemPath = ConfigurationManager.AppSettings["ProjectRootPath"] + @"\zasz.me\Content\Shared\Fonts";
            _Service = new FontsService();
            _Service.LoadFonts(SystemPath);
            FontsCombo.Items.AddRange(_Service.AvailableFonts.Keys.ToArray());
            StrategyCombo.Items.AddRange(Enum.GetNames(typeof (TagDisplayStrategy)));
            BgfgStrategyCombo.Items.AddRange(Enum.GetNames(typeof (Theme)));
            FgStrategyCombo.Items.AddRange(Enum.GetNames(typeof (Style)));
        }

        private void GenerateClick(object Sender, EventArgs E)
        {
            Cloud.Controls.Clear();
            string GenCloudSysPath = ConfigurationManager.AppSettings["ProjectRootPath"] +
                                @"\zasz.develop\Data\TagCloud\Cloud.png";
            Dictionary<string, int> Tags = Words.Lines.Select(
                Line => Line.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries))
                .Where(Splits => Splits.Length == 2)
                .ToDictionary(Splits => Splits[0], Splits => int.Parse(Splits[1]));
            var TagCloudService = new TagCloudService(Tags, int.Parse(Width.Text), int.Parse(Height.Text))
                                      {
                                          MaximumFontSize = float.Parse(MaxFontSize.Text),
                                          MinimumFontSize = float.Parse(MinFontSize.Text),
                                      };
            if (!String.IsNullOrEmpty(Angle.Text)) TagCloudService.Angle = int.Parse(Angle.Text);
            if (!String.IsNullOrEmpty(Margin.Text)) TagCloudService.Margin = int.Parse(Margin.Text);
            if (null != FontsCombo.SelectedItem)
                TagCloudService.SelectedFont = _Service.AvailableFonts[FontsCombo.SelectedItem.ToString()];
            if (null != StrategyCombo.SelectedItem)
                TagCloudService.DisplayChoice = DisplayStrategy.Get(
                    (TagDisplayStrategy) Enum.Parse(typeof (TagDisplayStrategy), StrategyCombo.SelectedItem.ToString()));
            Theme BgfgScheme = null != BgfgStrategyCombo.SelectedItem
                                   ? (Theme) Enum.Parse(typeof (Theme), BgfgStrategyCombo.SelectedItem.ToString())
                                   : Theme.LightBgDarkFg;
            Style FgScheme = null != FgStrategyCombo.SelectedItem
                                 ? (Style) Enum.Parse(typeof (Style), FgStrategyCombo.SelectedItem.ToString())
                                 : Style.Varied;
            TagCloudService.ColorChoice = ColorStrategy.Get(BgfgScheme, FgScheme, _Bg, _Fg);
            TagCloudService.VerticalTextRight = VerticalTextRight.Checked;
            TagCloudService.ShowWordBoundaries = ShowBoundaries.Checked;
            TagCloudService.Crop = Cropper.Checked;
            Dictionary<string, RectangleF> Borders;
            Bitmap Bitmap = TagCloudService.Construct(out Borders);
            Skipped.Text = string.Join("; ", TagCloudService.WordsSkipped.Select(It => It.Key));
            Bitmap.Save(GenCloudSysPath, ImageFormat.Png);
            Cloud.Image = Bitmap;
            Borders.Values.ToList().ForEach(It => Cloud.Controls.Add(GetBorder(It)));
        }

        private Control GetBorder(RectangleF Borders)
        {
            Rectangle It = Rectangle.Round(Borders);
            Label Border = new Label
                               {
                                   Top = It.Top,
                                   Left = It.Left,
                                   Width = It.Width,
                                   Height = It.Height,
                                   BackColor = Color.FromArgb(0, Color.White)
                               };
            Border.MouseEnter += OnEnter;
            Border.MouseLeave += OnLeave;
            return Border;
        }

        private void OnEnter(object Sender, EventArgs E)
        {
            ((Label)Sender).BorderStyle = BorderStyle.FixedSingle;
        }

        private void OnLeave(object Sender, EventArgs E)
        {
            ((Label)Sender).BorderStyle = BorderStyle.None;
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

        private void TagCloudFormClosing(object sender, FormClosingEventArgs e)
        {
            _Service.Dispose();
        }
    }
}