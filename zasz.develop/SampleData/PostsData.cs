using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using zasz.develop.Utils;
using zasz.me.Models;

namespace zasz.develop.SampleData
{
    public static class PostsData
    {
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
                foreach (XmlNode node in PostDoc.SelectNodes("post/tags/tag"))
                {
                    if (!string.IsNullOrEmpty(node.InnerText))
                        NewPost.Tags.Add(node.InnerText);
                }
                yield return NewPost;
            }
        }
    }
}