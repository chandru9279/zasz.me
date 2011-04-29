using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using zasz.develop.Utils;
using zasz.me.Integration.EntityFramework;
using zasz.me.Models;

namespace zasz.develop.SampleData
{
    public static class PostsData
    {
        private static Dictionary<string, string> _Map;

        public static Dictionary<string, string> DefaultSiteMap
        {
            get
            {
                return _Map ?? (_Map = new[]
                                           {
                                               new[] {"About-Dota-660", "Rest"},
                                               new[] {"Back-to-Chennai", "Rest"},
                                               new[] {"Bing!", "Pro"},
                                               new[] {"Blizzard-Starcraft-2-Patch-11-Woes", "Rest"},
                                               new[] {"BlizzCon-2010-!!", "Rest"},
                                               new[] {"Browser-2-0-Part-I", "Pro"},
                                               new[] {"Cant-Wait2c-Im-Sorry", "Rest"},
                                               new[] {"Charisma", "Pro"},
                                               new[] {"Clan-Feeders-is-ONLINE", "Rest"},
                                               new[] {"Comedy-Family-Tree", "Rest"},
                                               new[] {"Default-button-in-ASPNET", "Pro"},
                                               new[] {"Defense-of-the-Pendragon---LOL", "Rest"},
                                               new[] {"Does-PrincipalPermission-fail-always", "Pro"},
                                               new[] {"Dota-660", "Rest"},
                                               new[] {"End-of-Holidays-in-Horizon-(", "Rest"},
                                               new[] {"Essential-Tip-for-any-ASPNET-developer", "Pro"},
                                               new[] {"Fact-and-Fiction", "Rest"},
                                               new[] {"Feeder-Friends", "Rest"},
                                               new[] {"FEEDER-STORIES", "Rest"},
                                               new[] {"Five-Minute-ASPNETMVC", "Pro"},
                                               new[] {"From-The-Studio-To-Release", "Pro"},
                                               new[] {"Game-On", "Rest"},
                                               new[] {"Getting-started-with-Apache-Struts-2-2c-with-Netbeans-61", "Pro"},
                                               new[] {"Gin-GWT-Command-Pattern", "Pro"},
                                               new[] {"Graduated-!!", "Rest"},
                                               new[] {"Greatest-Content-of-late-2008", "Rest"},
                                               new[] {"Groovy-and-Grails-3d-GG", "Pro"},
                                               new[] {"GWT-code-splitting-best-practice-is-not-really-best-practice", "Pro"},
                                               new[] {"GWT-Library", "Pro"},
                                               new[] {"Home-PC-v30", "Rest"},
                                               new[] {"Integrity", "Pro"},
                                               new[] {"I-want-to-see-BlizzCon-12", "Rest"},
                                               new[] {"Login-control-ASPNET-works-in-Firefox-but-not-in-IE", "Pro"},
                                               new[] {"Moving-the-MBR-to-another-DeviceHard-Disk", "Pro"},
                                               new[] {"Nested-MasterPages-seems-to-have-an-egg-or-two", "Pro"},
                                               new[] {"New-Kind-of-Advertising--Spamming-around", "Pro"},
                                               new[] {"On-the-other-hand", "Rest"},
                                               new[] {"Play-DotA", "Rest"},
                                               new[] {"Pre-Fetching-Troubles-A-Good-Idea", "Pro"},
                                               new[] {"ReBlog--Has-Google-Blundered-with-the-Gmail-Beta", "Pro"},
                                               new[] {"Starcraft-2-Opts-out-of-local-Multiplayer", "Rest"},
                                               new[] {"This-site-is-going-to-get-an-overhaul!", "Both"},
                                               new[] {"ThoughtWorks", "Pro"},
                                               new[] {"Training-At-TWU", "Pro"},
                                               new[] {"USB-Guard", "Pro"},
                                               new[] {"Welcome-to-ZaszBlog", "Rest"},
                                               new[] {"WTF-Sadness", "Rest"},
                                               new[] {"ZaszzasZ", "Rest"},
                                           }.ToDictionary(Entry => Entry[0], Entry => Entry[1]));
            }
        }

        /// <summary>
        ///     Gets Post objects out of XML files, which follow the BlogEngine.NET format.
        /// </summary>
        /// <param name = "FolderSystemPath">Folder where XML files are located</param>
        /// <param name = "Log">An action to which logs are sent</param>
        /// <returns>zasz.me.Models.Post objects</returns>
        public static IEnumerable<Post> GetFromFolder(string FolderSystemPath, Action<string> Log)
        {
            Action<string> Die = DieLog =>
                                     {
                                         Log(DieLog);
                                         throw new Death(DieLog);
                                     };

            if (String.IsNullOrEmpty(FolderSystemPath))
                Die("Null Path");

            string[] Files = Directory.GetFiles(FolderSystemPath);
            var XmlFiles = from AFile in Files
                           where AFile.EndsWith(".xml")
                           select AFile;

            if (XmlFiles.Count() == 0)
                Die("No XML Files found");

            foreach (string PostFile in XmlFiles)
            {
                Log("Working on file : " + PostFile);
                Post NewPost = new Post();
                XmlDocument PostDoc = new XmlDocument();
                PostDoc.Load(PostFile);
                NewPost.Title = PostDoc.SelectSingleNode("post/title").InnerText;
                Log("Title : " + NewPost.Title);
                NewPost.Content = HttpUtility.HtmlDecode(PostDoc.SelectSingleNode("post/content").InnerText);
                NewPost.Timestamp = DateTime.Parse(PostDoc.SelectSingleNode("post/pubDate").InnerText);
                NewPost.Slug = PostDoc.SelectSingleNode("post/slug").InnerText;
                NewPost.Tags = new List<Tag>();
                foreach (XmlNode node in PostDoc.SelectNodes("post/tags/tag"))
                {
                    if (!string.IsNullOrEmpty(node.InnerText))
                        NewPost.Tags.Add(new Tag(node.InnerText));
                }
                yield return NewPost;
            }

            yield break;
        }


        public static void RegisterSites()
        {
            Site.Register("zasz.me", "Rest");
            Site.Register("AnyHost", "Admin", "~/Home/Show");
            Site.Register("AnyHost", "Both", "~/Home/Show");
            Site.Register("chandruon.net", "Pro");
            Site.Register("localhost", "Pro");
        }
    }
}