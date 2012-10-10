using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;

namespace zasz.me.Services.TagCloud
{
    public class FontsService : IDisposable
    {
        // ReSharper disable InconsistentNaming
        private readonly Action<string> Die = Message => { throw new Exception(Message); };
        // ReSharper restore InconsistentNaming

        private PrivateFontCollection fonts;


        /// <summary>
        /// A list of private fonts used by this service. It is loaded from the
        /// path given while construction. It expects .ttf files (TrueType Font)
        /// </summary>
        public Dictionary<string, FontFamily> AvailableFonts { get; private set; }

        #region IDisposable Members

        public void Dispose()
        {
            fonts.Dispose();
        }

        #endregion

        public void LoadFonts(string fontsFolderPath)
        {
            if (string.IsNullOrEmpty(fontsFolderPath)) Die("Null Fonts Path");
            var files = Directory.GetFiles(fontsFolderPath);
            var fontFiles = (from file in files
                             where file.EndsWith(".ttf")
                             select file).ToList();
            if (!fontFiles.Any()) Die("No Fonts Found");
            fonts = new PrivateFontCollection();
            fontFiles.ForEach(f => fonts.AddFontFile(f));
            AvailableFonts = fonts.Families.ToDictionary(x => x.Name);
        }
    }
}