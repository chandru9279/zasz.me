using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using zasz.me;
using zasz.me.Models;

namespace zasz.health.UtilityTests
{
    public class PostsData
    {
        private readonly Action<string> die;
        private readonly Action<string> log;

        public PostsData(Action<string> log)
        {
            this.log = log;
            die = dieLog =>
                      {
                          log(dieLog);
                          throw new Exception(dieLog);
                      };
        }

        /// <summary>
        ///     Gets Post objects out of XML files, which follow the BlogEngine.NET format.
        /// </summary>
        /// <param name = "folderSystemPath">Folder where XML files are located</param>
        /// <returns>zasz.me.Models.Post objects</returns>
        public IEnumerable<Post> GetFromFolder(string folderSystemPath)
        {
            if (String.IsNullOrEmpty(folderSystemPath))
                die("Null Path");

            Debug.Assert(folderSystemPath != null, "folderSystemPath != null");
            var files = Directory.GetFiles(folderSystemPath);
            var xmlFiles = (from file in files
                           where file.EndsWith(".xml")
                           select file).ToList();

            if (!xmlFiles.Any())
                die("No XML Files found");
            // ReSharper disable PossibleNullReferenceException
            foreach (var postFile in xmlFiles)
            {
                log("Working on file : " + postFile);
                var newPost = new Post();
                var postDoc = new XmlDocument();
                postDoc.Load(postFile);
                newPost.Title = postDoc.SelectSingleNode("post/title").InnerText;
                log("Title : " + newPost.Title);
                newPost.Content = HttpUtility.HtmlDecode(postDoc.SelectSingleNode("post/content").InnerText);
                newPost.Timestamp = DateTime.Parse(postDoc.SelectSingleNode("post/pubDate").InnerText);
                newPost.Slug = postDoc.SelectSingleNode("post/slug").InnerText;
                newPost.Tags = new List<Tag>();
                postDoc.SelectNodes("post/tags/tag")
                    .Cast<XmlNode>()
                    .Where(node => !string.IsNullOrEmpty(node.InnerText))
                    .ForEach( x => newPost.Tags.Add(new Tag(x.InnerText)));
                yield return newPost;
            }
            // ReSharper restore PossibleNullReferenceException
        }

        public void ExportToFolders(List<Post> posts)
        {
            var postsFolder = X.RepoPath + @"zasz.me\App_Data\Posts";

        }
    }
}