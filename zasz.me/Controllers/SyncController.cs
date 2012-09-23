using System;
using System.Collections.Generic;
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
        private readonly List<IPostPopulator> populators = new List<IPostPopulator>();
        private readonly IPostRepository posts;
        private readonly ITagRepository tags;

        protected SyncController(IPostRepository posts, ITagRepository tags)
        {
            this.posts = posts;
            this.tags = tags;
            populators.Add(new SlugPopulator());
            populators.Add(new TitleAndContentPopulator());
            populators.Add(new TagsPopulator(tags));
            populators.Add(new PostValidator());
        }


        [DefaultAction]
        public ActionResult Database()
        {
            var folders = Directory.GetDirectories(Server.MapPath(@"~\App_Data\Posts"));
            List<string> errors = null;
            foreach (var folder in folders)
            {
                var entry = new Post();
                var dir = new DirectoryInfo(folder);
                errors = populators.Select(x =>
                                               {
                                                   try
                                                   {
                                                       x.Populate(entry, dir);
                                                       return string.Format("{0} is OK.", entry.Slug);
                                                   }
                                                   catch (Exception e)
                                                   {
                                                       return string.Format("{0} | {1} | {2}", entry.Slug, e.GetType(),
                                                                            e.Message);
                                                   }
                                               }).ToList();
                posts.Save(entry);
                posts.Commit();
            }
            return View(errors);
        }

        [DefaultAction]
        public ActionResult Solr()
        {
            return null;
        }

        /*[HttpPost]
        [Authorize]
        public ActionResult Manage(string postContent, string title, string tags, string slug)
        {
            if (isNew) entry.Timestamp = DateTime.Now;
        }*/
    }

    public class PostValidator : IPostPopulator
    {
        #region IPostPopulator Members

        public void Populate(Post post, DirectoryInfo directory)
        {
            post.Validate();
        }

        #endregion
    }

    public class TagsPopulator : IPostPopulator
    {
        private readonly ITagRepository repo;

        public TagsPopulator(ITagRepository repo)
        {
            this.repo = repo;
        }

        #region IPostPopulator Members

        public void Populate(Post post, DirectoryInfo directory)
        {
            var fileInfos = directory.GetFiles("*.txt");
            var content = fileInfos.First();
            var tags = new StreamReader(content.OpenRead()).ReadToEnd();
            post.Tags =
                tags.Split(Constants.Shredders, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => repo.Get(x) ?? repo.Save(new Tag(x)))
                    .ToList();
            post.Content = tags;
        }

        #endregion
    }

    public class SlugPopulator : IPostPopulator
    {
        #region IPostPopulator Members

        public void Populate(Post post, DirectoryInfo directory)
        {
            post.Slug = GetSlug(directory.Name);
        }

        #endregion

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

    public class TitleAndContentPopulator : IPostPopulator
    {
        #region IPostPopulator Members

        public void Populate(Post post, DirectoryInfo directory)
        {
            var fileInfos = directory.GetFiles("*.html");
            var content = fileInfos.First();
            post.Title = content.Name;
            post.Content = new StreamReader(content.OpenRead()).ReadToEnd();
        }

        #endregion
    }

    internal interface IPostPopulator
    {
        void Populate(Post post, DirectoryInfo directory);
    }
}