using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace zasz.me.Controllers
{
    public static class Handy
    {
        internal static bool DoesExtensionMatch(string Extension, string ExtensionList)
        {
            if (String.IsNullOrEmpty(ExtensionList)) return true;
            string[] Extensions = ExtensionList.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            return Extensions.Contains(Extension.ToLower().Remove(0, 1));
        }

        public static void GenerateThumbnail(string SavedFileName, string ThumbsDir, int ThumbWidth, int ThumbHeight)
        {
            try
            {
                Image PostedImage = Image.FromFile(SavedFileName);
                Image ThumbnailImage = PostedImage.GetThumbnailImage(ThumbWidth, ThumbHeight, () => true, IntPtr.Zero);
                ThumbnailImage.Save(ThumbsDir);
            }
            catch(Exception)
            {
                
            }




        }
    }
}