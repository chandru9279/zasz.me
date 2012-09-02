using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using zasz.develop.Utils;
using zasz.me.Areas.Shared.Models;

namespace zasz.develop.Data
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
                                               new[] {"About-Dota-660", Site.REST},
                                               new[] {"Back-to-Chennai", Site.REST},
                                               new[] {"Bing!", Site.PRO},
                                               new[] {"Blizzard-Starcraft-2-Patch-11-Woes", Site.REST},
                                               new[] {"BlizzCon-2010-!!", Site.REST},
                                               new[] {"Browser-2-0-Part-I", Site.PRO},
                                               new[] {"Cant-Wait2c-Im-Sorry", Site.REST},
                                               new[] {"Charisma", Site.PRO},
                                               new[] {"Clan-Feeders-is-ONLINE", Site.REST},
                                               new[] {"Comedy-Family-Tree", Site.REST},
                                               new[] {"Default-button-in-ASPNET", Site.PRO},
                                               new[] {"Defense-of-the-Pendragon---LOL", Site.REST},
                                               new[] {"Does-PrincipalPermission-fail-always", Site.PRO},
                                               new[] {"Dota-660", Site.REST},
                                               new[] {"End-of-Holidays-in-Horizon-(", Site.REST},
                                               new[] {"Essential-Tip-for-any-ASPNET-developer", Site.PRO},
                                               new[] {"Fact-and-Fiction", Site.REST},
                                               new[] {"Feeder-Friends", Site.REST},
                                               new[] {"FEEDER-STORIES", Site.REST},
                                               new[] {"Five-Minute-ASPNETMVC", Site.PRO},
                                               new[] {"From-The-Studio-To-Release", Site.PRO},
                                               new[] {"Game-On", Site.REST},
                                               new[] {"Getting-started-with-Apache-Struts-2-2c-with-Netbeans-61", Site.PRO},
                                               new[] {"Gin-GWT-Command-Pattern", Site.PRO},
                                               new[] {"Graduated-!!", Site.REST},
                                               new[] {"Greatest-Content-of-late-2008", Site.REST},
                                               new[] {"Groovy-and-Grails-3d-GG", Site.PRO},
                                               new[] {"GWT-code-splitting-best-practice-is-not-really-best-practice", Site.PRO},
                                               new[] {"GWT-Library", Site.PRO},
                                               new[] {"Home-PC-v30", Site.REST},
                                               new[] {"Integrity", Site.PRO},
                                               new[] {"I-want-to-see-BlizzCon-12", Site.REST},
                                               new[] {"Login-control-ASPNET-works-in-Firefox-but-not-in-IE", Site.PRO},
                                               new[] {"Moving-the-MBR-to-another-DeviceHard-Disk", Site.PRO},
                                               new[] {"Nested-MasterPages-seems-to-have-an-egg-or-two", Site.PRO},
                                               new[] {"New-Kind-of-Advertising--Spamming-around", Site.PRO},
                                               new[] {"On-the-other-hand", Site.REST},
                                               new[] {"Play-DotA", Site.REST},
                                               new[] {"Pre-Fetching-Troubles-A-Good-Idea", Site.PRO},
                                               new[] {"ReBlog--Has-Google-Blundered-with-the-Gmail-Beta", Site.PRO},
                                               new[] {"Starcraft-2-Opts-out-of-local-Multiplayer", Site.REST},
                                               new[] {"This-site-is-going-to-get-an-overhaul!", Site.SHARED},
                                               new[] {"ThoughtWorks", Site.PRO},
                                               new[] {"Training-At-TWU", Site.PRO},
                                               new[] {"USB-Guard", Site.PRO},
                                               new[] {"Welcome-to-ZaszBlog", Site.REST},
                                               new[] {"WTF-Sadness", Site.REST},
                                               new[] {"ZaszzasZ", Site.REST}
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
    }
}