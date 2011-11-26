using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Elmah;

namespace zasz.me.Areas.Shared.Controllers.Utils
{
    public static class Handy
    {
        public static List<string> Shred(string WordList)
        {
            return String.IsNullOrEmpty(WordList)
                       ? new List<string>()
                       : WordList.Split(Constants.Shredders, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public static T Enumize<T>(this string EnumValue)
        {
            return (T)Enum.Parse(typeof(T), EnumValue);
        }

        public static IEnumerable<SelectListItem> ToSelectList(this List<string> AnyList)
        {
            return AnyList.Select(It => new SelectListItem {Text = It, Value = It});
        }

        public static void Log(string Message)
        {
            ErrorSignal.FromCurrentContext().Raise(new ZaszDotMeException(Message));
        }
        
        public static void Log(string Message, Exception E)
        {
            ErrorSignal.FromCurrentContext().Raise(new ZaszDotMeException(Message, E));
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
        /// <param name = "HtmlHelper"></param>
        /// <param name = "Data">The data to be encoded, as a string.</param>
        /// <param name = "Size">The square length of the resulting image, in pixels.</param>
        /// <param name = "Margin">The width of the border that surrounds the image, measured in rows (not pixels).</param>
        /// <param name = "ErrorCorrectionLevel">The amount of error correction to build into the image.  Higher error correction comes at the expense of reduced space for data.</param>
        /// <param name = "HtmlAttributes">Optional HTML attributes to include on the image element.</param>
        /// <returns></returns>
        public static MvcHtmlString QrCode(this HtmlHelper HtmlHelper, string Data, int Size = 80, int Margin = 4,
                                           QrCodeErrorCorrectionLevel ErrorCorrectionLevel =
                                               QrCodeErrorCorrectionLevel.Low, object HtmlAttributes = null)
        {
            if (Data == null)
                throw new ArgumentNullException("Data");
            if (Size < 1)
                throw new ArgumentOutOfRangeException("Size", Size, "Must be greater than zero.");
            if (Margin < 0)
                throw new ArgumentOutOfRangeException("Margin", Margin, "Must be greater than or equal to zero.");
            if (!Enum.IsDefined(typeof (QrCodeErrorCorrectionLevel), ErrorCorrectionLevel))
                throw new InvalidEnumArgumentException("ErrorCorrectionLevel", (int) ErrorCorrectionLevel,
                                                       typeof (QrCodeErrorCorrectionLevel));

            string Url = string.Format("http://chart.apis.google.com/chart?cht=qr&chld={2}|{3}&chs={0}x{0}&chl={1}",
                                       Size, HttpUtility.UrlEncode(Data), ErrorCorrectionLevel.ToString()[0], Margin);

            var Tag = new TagBuilder("img");
            if (HtmlAttributes != null)
                Tag.MergeAttributes(new RouteValueDictionary(HtmlAttributes));
            Tag.Attributes.Add("src", Url);
            Tag.Attributes.Add("width", Size.ToString());
            Tag.Attributes.Add("height", Size.ToString());

            return new MvcHtmlString(Tag.ToString(TagRenderMode.SelfClosing));
        }
    }

    public enum QrCodeErrorCorrectionLevel
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

    class ZaszDotMeException : Exception
    {
        public ZaszDotMeException(string Message) : base(Message)
        {
        }

        public ZaszDotMeException(string Message, Exception InnerException) : base(Message, InnerException)
        {
        }
    }
}