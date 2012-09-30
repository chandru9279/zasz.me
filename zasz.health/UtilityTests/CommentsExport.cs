using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml;
using Joel.Net;

namespace zasz.health.UtilityTests
{
    /* example : 
     * https://github.com/danielHalan/blogengine.net-comments-exporter/blob/master/src/App_Code/Extensions/CommentsExport.cs */
    public class CommentsExport
    {
        private const string dateFormat = "yyyy-MM-dd HH:mm:ss";
        private const string nsContent = "http://purl.org/rss/1.0/modules/content/";
        private const string nsDSQ = "http://www.disqus.com/";
        private const string nsWp = "http://wordpress.org/export/1.0/";
        private const string nsExcerpt = "http://wordpress.org/export/1.0/excerpt/";
        private const string nsWfw = "http://wellformedweb.org/CommentAPI/";
        private const string nsDc = "http://purl.org/dc/elements/1.1/";
        public const string AkismetApiKey = "94150f7474ea";
        private readonly Akismet api;
        private readonly Dictionary<string, string> namespaces = new Dictionary<string, string>(6);
        private int commentCount;
        private XmlDocument wxr;


        public CommentsExport()
        {
            namespaces.Add("wp", nsWp);
            namespaces.Add("dsq", nsDSQ);
            namespaces.Add("content", nsContent);
            namespaces.Add("excerpt", nsExcerpt);
            namespaces.Add("wfw", nsWfw);
            namespaces.Add("dc", nsDc);

            api = new Akismet(AkismetApiKey, "http://zasz.me/", "Test/1.0");
            if (!api.VerifyKey()) throw new Exception("Key not verified");
        }


        /// <summary>
        ///   Gets Comments out of XML files, which follow the BlogEngine.NET format.
        /// </summary>
        /// <param name = "folderSystemPath">Folder where XML files are located</param>
        public void ExportToWxr(string folderSystemPath)
        {
            Action<string> die = dieLog =>
                                     {
                                         Debug.WriteLine(dieLog);
                                         throw new Exception(dieLog);
                                     };

            if (String.IsNullOrEmpty(folderSystemPath))
                die("Null Path");

            var files = Directory.GetFiles(folderSystemPath);
            var xmlFiles = (from file in files
                           where file.EndsWith(".xml")
                           select file).ToList();

            if (!xmlFiles.Any())
                die("No XML Files found");

            wxr = new XmlDocument();
            wxr.AppendChild(wxr.CreateNode(XmlNodeType.XmlDeclaration, null, null));

            var rss = XElement("rss");
            foreach (var ns in namespaces)
                rss.SetAttribute("xmlns:" + ns.Key, ns.Value);

            wxr.AppendChild(rss);

            var root = XElement("channel");
            rss.AppendChild(root);


            foreach (var postFile in xmlFiles)
            {
                Log("Working on file : " + postFile);
                var postDoc = new XmlDocument();
                postDoc.Load(postFile);
                var title = Get(postDoc, "post/title");
                var slug = Get(postDoc, "post/slug");
                Log("Title : " + title);
                var item = XElement("item");
                root.AppendChild(item);

                item.AppendChild(XElement("title", title));
                item.AppendChild(XElement("link", Get(postDoc, "WHAT TO DO HERE?")));
                item.AppendChild(XElement("dsq:thread_identifier", slug));
                item.AppendChild(XElement("wp:post_date_gmt", Get(postDoc, "pubDate")));
                item.AppendChild(XElement("content:encoded", wxr.CreateCDataSection(Get(postDoc, "content"))));

                item.AppendChild(XElement("wp:post_id", slug));
                item.AppendChild(XElement("wp:comment_status", "open"));
                item.AppendChild(XElement("wp:ping_status", "open"));
                item.AppendChild(XElement("wp:post_type", "post"));

                foreach (XmlNode node in postDoc.SelectNodes("post/comments/comment"))
                {
                    var comment = new AkismetComment();
                    comment.Blog = "http://zasz.me/Blog";
                    comment.UserIp = Get(node, "ip");
                    comment.CommentContent = Get(node, "content");
                    comment.CommentAuthor = Get(node, "author");
                    comment.CommentAuthorEmail = Get(node, "email");
                    comment.CommentAuthorUrl = Get(node, "website");
                    comment.CommentType = "comment";
                    if (api.CommentCheck(comment))
                        continue;
                    var cmt = XElement("wp:comment");
                    cmt.AppendChild(XElement("wp:comment_id", (++commentCount).ToString()));
                    cmt.AppendChild(XElement("wp:comment_author", wxr.CreateCDataSection(comment.CommentAuthor)));
                    cmt.AppendChild(XElement("wp:comment_author_email", comment.CommentAuthorEmail));
                    cmt.AppendChild(XElement("wp:comment_author_url", comment.CommentAuthorUrl));
                    cmt.AppendChild(XElement("wp:comment_author_IP", comment.UserIp));
                    var date = DateTime.Parse(Get(node, "date")).ToString(dateFormat);
                    cmt.AppendChild(XElement("wp:comment_date", date));
                    cmt.AppendChild(XElement("wp:comment_date_gmt", date));
                    cmt.AppendChild(XElement("wp:comment_content", wxr.CreateCDataSection(comment.CommentContent)));
                    cmt.AppendChild(XElement("wp:comment_approved", "1"));
                    item.AppendChild(cmt);
                }
            }

            wxr.Save(folderSystemPath + @"\Comments\CommentsWXRAksimetFiltered.xml");
        }

        private static string Get(XmlNode node, string element)
        {
            var singleNode = node.SelectSingleNode(element);
            return singleNode == null ? "" : singleNode.InnerText;
        }


        private XmlElement XElement(string name, string value, params XmlAttribute[] attributes)
        {
            var e = name.IndexOf(':') != -1
                        ? wxr.CreateElement(name, namespaces[name.Split(':')[0]])
                        : wxr.CreateElement(name);

            if (value != null)
                e.InnerText = value;

            if (attributes != null)
                foreach (var atr in attributes)
                    e.Attributes.Append(atr);

            return e;
        }

        private XmlElement XElement(string name)
        {
            return XElement(name, null, (XmlAttribute[]) null);
        }

        private XmlElement XElement(string name, params XmlLinkedNode[] childs)
        {
            var e = name.IndexOf(':') != -1
                        ? wxr.CreateElement(name, namespaces[name.Split(':')[0]])
                        : wxr.CreateElement(name);

            if (childs != null)
                foreach (var child in childs)
                    e.AppendChild(child);

            return e;
        }

        private static void Log(string log)
        {
            Debug.WriteLine(log);
        }
    }
}

/*
 
 <?xml version="1.0" encoding="UTF-8"?>
<rss version="2.0"
  xmlns:content="http://purl.org/rss/1.0/modules/content/"
  xmlns:dsq="http://www.disqus.com/"
  xmlns:dc="http://purl.org/dc/elements/1.1/"
  xmlns:wp="http://wordpress.org/export/1.0/"
>
  <channel>
    <item>
      <!-- title of article -->
      <title>Foo bar</title>
      <!-- absolute URI to article -->
      <link>http://foo.com/example</link>
      <!-- thread body; use cdata; html allowed (though will be formatted to DISQUS specs) -->
      <content:encoded><![CDATA[Hello world]]></content:encoded>
      <!-- value used within disqus_identifier; usually internal identifier of article -->
      <dsq:thread_identifier>disqus_identifier</dsq:thread_identifier>
      <!-- creation date of thread (article), in GMT -->
      <wp:post_date_gmt>2010-09-20 09:13:44</wp:post_date_gmt>
      <!-- open/closed values are acceptable -->
      <wp:comment_status>open</wp:comment_status>
      <wp:comment>
        <!-- sso only; see docs -->
        <dsq:remote>
          <!-- unique internal identifier; username, user id, etc. -->
          <dsq:id>user id</dsq:id>
          <!-- avatar -->
          <dsq:avatar>http://url.to/avatar.png</dsq:avatar>
        </dsq:remote>
        <!-- internal id of comment -->
        <wp:comment_id>65</wp:comment_id>
        <!-- author display name -->
        <wp:comment_author>Foo Bar</wp:comment_author>
        <!-- author email address -->
        <wp:comment_author_email>foo@bar.com</wp:comment_author_email>
        <!-- author url, optional -->
        <wp:comment_author_url>http://www.foo.bar/</wp:comment_author_url>
        <!-- author ip address -->
        <wp:comment_author_IP>93.48.67.119</wp:comment_author_IP>
        <!-- comment datetime, in GMT -->
        <wp:comment_date_gmt>2010-09-20 13:19:10</wp:comment_date_gmt>
        <!-- comment body; use cdata; html allowed (though will be formatted to DISQUS specs) -->
        <wp:comment_content><![CDATA[Hello world]]></wp:comment_content>
        <!-- is this comment approved? 0/1 -->
        <wp:comment_approved>1</wp:comment_approved>
        <!-- parent id (match up with wp:comment_id) -->
        <wp:comment_parent>0</wp:comment_parent>
      </wp:comment>
    </item>
  </channel>
</rss>
 
*/