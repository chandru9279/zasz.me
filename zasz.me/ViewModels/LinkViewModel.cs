using System.Collections.Generic;
using System.Drawing;

namespace zasz.me.ViewModels
{
    public class LinkViewModel
    {
        public Dictionary<string, RectangleF> Borders { get; set; }
        public float GenerateTime { get; set; }
        public string Skipped { get; set; }
    }
}