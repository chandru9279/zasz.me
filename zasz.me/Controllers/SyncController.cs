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
    [Authorize]
    public class SyncController : BaseController
    {
        public const string PostsFolder = @"\App_Data\Posts\";
        private readonly List<IPostPopulator> populators;
        private readonly IPostRepository posts;

        protected SyncController(IPostRepository posts, IPostPopulators populators)
        {
            this.posts = posts;
            this.populators = populators.All();
        }


        [DefaultAction]
        public ActionResult Database()
        {
            var folders = Directory.GetDirectories(Server.MapPath("~" + PostsFolder));
            List<string> errors = null;
            foreach (var folder in folders)
            {
                var entry = new Post();
                var dir = new DirectoryInfo(folder);
                errors = populators
                    .Select(x =>
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
    }
}