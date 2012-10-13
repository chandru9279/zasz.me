using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using zasz.me.Integration.MVC;
using zasz.me.Models;
using zasz.me.Services.Contracts;

namespace zasz.me.Controllers
{
    [LoggedIn]
    [Secure]
    public class SyncController : BaseController
    {
        public const string PostsFolder = @"\App_Data\Posts\";
        private readonly List<IPostPopulator> populators;
        private readonly IPostRepository posts;

        public SyncController(IPostRepository posts, IPostPopulators populators)
        {
            this.posts = posts;
            this.populators = populators.All();
        }


        [DefaultAction]
        public ActionResult Database()
        {
            posts.DeleteAll();
            var folders = Directory.GetDirectories(Server.MapPath("~" + PostsFolder));
            var errors = new List<string>();
            foreach (var folder in folders)
            {
                var entry = new Post();
                var dir = new DirectoryInfo(folder);
                var postErrors = populators.Select(x =>
                                                     {
                                                         try
                                                         {
                                                             x.Populate(entry, dir);
                                                             return string.Format("{0} | {1} is OK.", entry.Slug, x.GetType().Name);
                                                         }
                                                         catch (Exception e)
                                                         {
                                                             return string.Format("{0} | {1} | {2}", entry.Slug, e.GetType(), e.Message);
                                                         }
                                                     }).ToList();
                errors.AddRange(postErrors);
                if (!postErrors.Any()) posts.Save(entry);
                posts.Commit();
            }
            return View(errors);
        }

        public ActionResult Solr()
        {
            return null;
        }
    }
}