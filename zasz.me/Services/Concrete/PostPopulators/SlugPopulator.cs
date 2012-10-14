using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using zasz.me.Controllers.Utils;
using zasz.me.Models;
using zasz.me.Services.Contracts;

namespace zasz.me.Services.Concrete.PostPopulators
{
    public class SlugPopulator : IPostPopulator
    {
        #region IPostPopulator Members

        public void Populate(Post post, DirectoryInfo directory)
        {
            post.Slug = GetSlug(directory.Name);
        }

        #endregion

        internal virtual string GetSlug(string title)
        {
            var decodedTitle = HttpUtility.HtmlDecode(title).ToLower();
            var nearlySlug = Constants.GoWords.Aggregate
                (
                    decodedTitle,
                    (current, pair) => current.Replace(pair.Key, " " + pair.Value + " ")
                );
            var sluglets = (from Match match in Regex.Matches(nearlySlug, @"[a-zA-Z0-9.-]+") select match.ToString());
            return string.Join("-", sluglets);
        }
    }
}