using System.Collections.Generic;
using System.Web;
using zasz.me.Services;

namespace zasz.me.Controllers.Utils
{
    public static class Constants
    {
        public static readonly Dictionary<string, string> GoWords = new Dictionary<string, string>
            {
                {"c#", "c-sharp"},
                {".net", "dot-net"},
                {"c++", "c-plus-plus"},
                {"&", "and"},
                {"%", "percent"},
                {"@", "at"},
                {"=", "equals"},
                {"+", "plus"},
                {"=>", "implies"},
                {"\\", "or"},
                {"/", "or"},
                {"F#", "j-sharp"},
                {"J#", "f-sharp"}
            };

        public static char[] Shredders = new[] { ' ', ',', ';', '|' };

        public static Pairs<string, int> Months = new Pairs<string, int>(new[]
                    {
                        "January", "February", "March", "April", "May", 
                        "June", "July", "August", "September", "October",
                        "November", "December"
                    }, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });

        public static string DefaultWordList =
@"asp.net, 15
games, 10
fun, 15
books, 5
music, 5
crapo, 4
dota, 5
concept, 2
.net, 5
fiction, 5
sci-fi, 3
mystery, 5
romance, 4
";

        public const string PostsFolder = @"\App_Data\Posts\";

        public const string SolrReindexUrl =
            @"http://localhost:5000/solr/dataimport?verbose=true&clean=true&commit=true&command=full-import";

        public const string PngContentType = "image/png";
        public const string PostContent = @"\PostContent";
        public const string AnchorPng = PostContent + @"\Anchor.png";

        public static readonly Dictionary<string, string> MimeMap =
            new Dictionary<string, string>
            {
                {"mathml", "application/mathml+xml"},
                {"doc", "application/msword"},
                {"bin","application/octet-stream"},
                {"exe","application/octet-stream"},
                {"class","application/octet-stream"},
                {"dll","application/octet-stream"},
                {"jar","application/octet-stream"},
                {"war","application/octet-stream"},
                {"oda", "application/oda"},
                {"ogg", "application/ogg"},
                {"pdf", "application/pdf"},
                {"ps", "application/postscript"},
                {"eps", "application/postscript"},
                {"ai", "application/postscript"},
                {"rdf", "application/rdf+xml"},
                {"xls", "application/vnd.ms-excel"},
                {"ppt", "application/vnd.ms-powerpoint"},
                {"dvi", "application/x-dvi"},
                {"js", "application/x-javascript"},
                {"sh", "application/x-sh"},
                {"swf", "application/x-shockwave-flash"},
                {"tar", "application/x-tar"},
                {"tgz", "application/x-tar"},
                {"xhtml", "application/xhtml+xml"},
                {"xht", "application/xhtml+xml"},
                {"xsl", "application/xml"},
                {"xml", "application/xml"},
                {"dtd", "application/xml-dtd"},
                {"xslt", "application/xslt+xml"},
                {"zip", "application/zip"},
                {"midi", "audio/midi"},
                {"kar", "audio/midi"},
                {"mid", "audio/midi"},
                {"mpga", "audio/mpeg"},
                {"mp2", "audio/mpeg"},
                {"mp3", "audio/mpeg"},
                {"m3u", "audio/x-mpegurl"},
                {"rpm", "audio/x-pn-realaudio-plugin"},
                {"ra", "audio/x-realaudio"},
                {"wav", "audio/x-wav"},
                {"pdb", "chemical/x-pdb"},
                {"bmp", "image/bmp"},
                {"cgm", "image/cgm"},
                {"gif", "image/gif"},
                {"ief", "image/ief"},
                {"jpg", "image/jpeg"},
                {"jpe", "image/jpeg"},
                {"jpeg", "image/jpeg"},
                {"png", "image/png"},
                {"svg", "image/svg+xml"},
                {"tif", "image/tiff"},
                {"tiff", "image/tiff"},
                {"ico", "image/x-icon"},
                {"xbm", "image/x-xbitmap"},
                {"xpm", "image/x-xpixmap"},
                {"xwd", "image/x-xwindowdump"},
                {"css", "text/css"},
                {"shtml", "text/html"},
                {"htm", "text/html"},
                {"html", "text/html"},
                {"txt", "text/plain"},
                {"asc", "text/plain"},
                {"rtx", "text/richtext"},
                {"rtf", "text/rtf"},
                {"sgm", "text/sgml"},
                {"sgml", "text/sgml"},
                {"tsv", "text/tab-separated-values"},
                {"mpg", "video/mpeg"},
                {"mpe", "video/mpeg"},
                {"mpeg", "video/mpeg"},
                {"mov", "video/quicktime"},
                {"qt", "video/quicktime"},
                {"avi", "video/x-msvideo"},
                {"movie", "video/x-sgi-movie"},
            };
    }
}