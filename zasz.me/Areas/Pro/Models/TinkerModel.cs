﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [StringLength(800, MinimumLength = 10, ErrorMessage = "You must enter text only between 10 and 800 characters")]
        public string Words { get; set; }
        [Range(-360, 360, ErrorMessage = "Angle has to be between -360 and 360")]
        public string Angle { get; set; }
        [Range(0, 200, ErrorMessage = "Range has to be between 0 and 200 pixels only")]
        public string Margin { get; set; }
        [Range(2, 200, ErrorMessage = "MaxFontSize has to be between 2 and 200 pixels only")]
        public string MaxFontSize { get; set; }
        [Range(2, 2100, ErrorMessage = "MinFontSize has to be between 0 and 200 pixels only")]
        public string MinFontSize { get; set; }
        [Required(ErrorMessage = "Width is required for generating the cloud image.")]
        [Range(10, 5000, ErrorMessage = "Width has to be between 10 and 5000 pixels only")]
        public string Width { get; set; }
        [Required(ErrorMessage = "Height is required for generating the cloud image.")]
        [Range(10, 5000, ErrorMessage = "Height has to be between 10 and 5000 pixels only")]
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