using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using zasz.me.Controllers.Utils;
using zasz.me.Integration.MVC;
using zasz.me.Models;

namespace zasz.me.Controllers
{
    /* Need to delete this controller and use Routing to do this*/

    public class SyncController : BaseController
    {
        private readonly IPostRepository posts;
        private readonly ITagRepository tags;

        protected SyncController(IPostRepository posts, ITagRepository tags)
        {
            this.posts = posts;
            this.tags = tags;
        }


        [DefaultAction]
        public ActionResult Database()
        {
            var folders = Directory.GetDirectories(Server.MapPath(@"~\App_Data\"));
            foreach (var folder in folders)
            {
                var entry = new Post();
            }
            return null;
        }

        [DefaultAction]
        public ActionResult Solr()
        {
            return new FilePathResult("~/Content/favicon.png", "image/png");
        }

        [HttpPost]
        [Authorize]
        public ActionResult Manage(string postContent, string title, string tags, string slug)
        {
            var isNew = string.IsNullOrEmpty(slug);

            var entry = isNew ? new Post() : posts.Get(slug);

            entry.Title = title;
            entry.Content = postContent;
            if (entry.Tags != null) entry.Tags.Clear();
            entry.Tags =
                tags.Split(Constants.Shredders, StringSplitOptions.RemoveEmptyEntries).Select(
                    x => this.tags.Get(x) ?? this.tags.Save(new Tag(x))).
                    ToList();
            if (isNew) entry.Slug = GetSlug(title);
            if (isNew) entry.Timestamp = DateTime.Now;

            if (isNew)
                if (ModelState.IsValid)
                    posts.Save(entry);
                else
                    return View("manageViewPath", entry);

            posts.Commit();
            return Redirect("/Blog/Post/" + entry.Slug);
        }

        public static string GetSlug(string title)
        {
            var decodedTitle = HttpUtility.HtmlDecode(title).ToLower();
            var nearlySlug = Constants.GoWords().Aggregate
                (
                    decodedTitle,
                    (current, pair) => current.Replace(pair.Key, " " + pair.Value + " ")
                );
            var sluglets = (from object match in Regex.Matches(nearlySlug, @"[a-zA-Z0-9.-]+") select match.ToString());
            return string.Join("-", sluglets);
        }
    }
}