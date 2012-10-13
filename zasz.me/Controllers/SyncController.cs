using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using zasz.me.Integration.MVC;
using zasz.me.Models;
using zasz.me.Services;
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
            var messagesAndErrors = new List<Pair<string, bool>>();
            foreach (var folder in folders)
            {
                var entry = new Post();
                var dir = new DirectoryInfo(folder);
                var postMessagesAndErrors = populators.Select(x =>
                                                     {
                                                         try
                                                         {
                                                             x.Populate(entry, dir);
                                                             return new Pair<string, bool>(string.Format("{0} | {1} is OK.", entry.Slug, x.GetType().Name), true);
                                                         }
                                                         catch (Exception e)
                                                         {
                                                             return new Pair<string, bool>(string.Format("{0} | {1} | {2}", entry.Slug, e.GetType(), e.Message), false);
                                                         }
                                                     }).ToList();
                messagesAndErrors.AddRange(postMessagesAndErrors);
                if (postMessagesAndErrors.All(x => x.Other)) posts.Save(entry);
                posts.Commit();
            }
            return View(messagesAndErrors);
        }

        public ActionResult Solr()
        {
            return null;
        }
    }
}