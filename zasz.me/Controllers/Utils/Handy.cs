using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace zasz.me.Controllers.Utils
{
    public static class Handy
    {
        public static List<string> Shred(string WordList)
        {
            if (String.IsNullOrEmpty(WordList)) return new List<string>();
            return WordList.Split(Constants.Shredders, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public static void GenerateThumbnail(string SavedFileName, string ThumbsDir, int ThumbWidth, int ThumbHeight)
        {
            try
            {
                Image PostedImage = Image.FromFile(SavedFileName);
                Image ThumbnailImage = PostedImage.GetThumbnailImage(ThumbWidth, ThumbHeight, () => true, IntPtr.Zero);
                ThumbnailImage.Save(ThumbsDir);
            }
            catch (Exception)
            {
                
            }
        }

    }
}