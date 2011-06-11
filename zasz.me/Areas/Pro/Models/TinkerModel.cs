using System;
using System.Collections.Generic;
using System.Drawing;
using zasz.me.Areas.Shared.Controllers.Utils;
using zasz.me.Services;

namespace zasz.me.Areas.Pro.Models
{
    public class TinkerModel
    {
        
        /*Sent only*/
        public List<string> Fonts { get; set; }
        public List<string> Strategies { get; set; }
        public List<string> Themes { get; set; }
        public List<string> Styles { get; set; }
        public Dictionary<string, RectangleF> Borders { get; set; }
        
        /*Posted & Defaults sent*/
        public string SelectedFont { get; set; }
        public string SelectedStrategy { get; set; }
        public string SelectedTheme { get; set; }
        public string SelectedStyle { get; set; }

        public string Words { get; set; }
        public string Angle { get; set; }
        public string Margin { get; set; }
        public string MaxFontSize { get; set; }
        public string MinFontSize { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string Skipped { get; set; }

        public bool VerticalTextRight { get; set; }
        public bool ShowBoundaries { get; set; }
        public bool Crop { get; set; }

        public TinkerModel()
        {
            Fonts = new List<string>();
            Strategies = new List<string>();
            Themes = new List<string>();
            Styles = new List<string>();

            SelectedFont = "Kenyan Coffee";
            SelectedStrategy = TagDisplayStrategy.RandomHorizontalOrVertical.ToString();
            SelectedTheme = Theme.LightBgDarkFg.ToString();
            SelectedStyle = Style.Varied.ToString();

            Words = Constants.DefaultWordList;
            Angle = "";
            Margin = "";
            MaxFontSize = "72";
            MinFontSize = "12";
            Width = "500";
            Height = "500";
        }

        public string[] Lines
        {
            get { return Words.Split(new[] {'\n'}, StringSplitOptions.RemoveEmptyEntries); }
        }
    }
}