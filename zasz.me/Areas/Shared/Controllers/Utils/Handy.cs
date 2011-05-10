using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Caching;
using System.Web.Mvc;

namespace zasz.me.Areas.Shared.Controllers.Utils
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

        public static List<T> Collect<X, T>(this List<X> TheList, Func<X, T> FieldSelector)
        {
            List<T> Fields = new List<T>(TheList.Count);
            TheList.ForEach(Item => Fields.Add(FieldSelector(Item)));
            return Fields;
        }

        /* This mad method will expire all output cache, i.e., every cached action is invalidated.
         * http://stackoverflow.com/questions/5326230/mvc3-outputcache-removeoutputcacheitem-renderaction*/

        public static void InvalidateOutputCache()
        {
            OutputCacheAttribute.ChildActionCache = new MemoryCache("NewDefault");
        }
    }
}