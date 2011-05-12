using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace zasz.me.Areas.Shared.Controllers.Utils
{
    public static class Handy
    {
        public static List<string> Shred(string WordList)
        {
            return String.IsNullOrEmpty(WordList) ? new List<string>() : WordList.Split(Constants.Shredders, StringSplitOptions.RemoveEmptyEntries).ToList();
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

        

        /// <summary>
        ///     http://stackoverflow.com/questions/3793799/qr-code-generation-in-asp-net-mvc
        ///     Produces the markup for an image element that displays a QR Code image, as provided by Google's chart API.
        /// </summary>
        /// <param name = "htmlHelper"></param>
        /// <param name = "data">The data to be encoded, as a string.</param>
        /// <param name = "size">The square length of the resulting image, in pixels.</param>
        /// <param name = "margin">The width of the border that surrounds the image, measured in rows (not pixels).</param>
        /// <param name = "errorCorrectionLevel">The amount of error correction to build into the image.  Higher error correction comes at the expense of reduced space for data.</param>
        /// <param name = "htmlAttributes">Optional HTML attributes to include on the image element.</param>
        /// <returns></returns>
        public static MvcHtmlString QRCode(this HtmlHelper htmlHelper, string data, int size = 80, int margin = 4, QRCodeErrorCorrectionLevel errorCorrectionLevel = QRCodeErrorCorrectionLevel.Low, object htmlAttributes = null)
        {
            if (data == null)
                throw new ArgumentNullException("data");
            if (size < 1)
                throw new ArgumentOutOfRangeException("size", size, "Must be greater than zero.");
            if (margin < 0)
                throw new ArgumentOutOfRangeException("margin", margin, "Must be greater than or equal to zero.");
            if (!Enum.IsDefined(typeof (QRCodeErrorCorrectionLevel), errorCorrectionLevel))
                throw new InvalidEnumArgumentException("errorCorrectionLevel", (int) errorCorrectionLevel, typeof (QRCodeErrorCorrectionLevel));

            var url = string.Format("http://chart.apis.google.com/chart?cht=qr&chld={2}|{3}&chs={0}x{0}&chl={1}", size, HttpUtility.UrlEncode(data), errorCorrectionLevel.ToString()[0], margin);

            var tag = new TagBuilder("img");
            if (htmlAttributes != null)
                tag.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            tag.Attributes.Add("src", url);
            tag.Attributes.Add("width", size.ToString());
            tag.Attributes.Add("height", size.ToString());

            return new MvcHtmlString(tag.ToString(TagRenderMode.SelfClosing));
        }
    }

    public enum QRCodeErrorCorrectionLevel
    {
        /// <summary>
        ///     Recovers from up to 7% erroneous data.
        /// </summary>
        Low,
        /// <summary>
        ///     Recovers from up to 15% erroneous data.
        /// </summary>
        Medium,
        /// <summary>
        ///     Recovers from up to 25% erroneous data.
        /// </summary>
        QuiteGood,
        /// <summary>
        ///     Recovers from up to 30% erroneous data.
        /// </summary>
        High
    }
}