/* 
 * This adapted BlogEngine.NET extension converts the comments into WXR
 * https://github.com/danielHalan/blogengine.net-comments-exporter/blob/master/src/App_Code/Extensions/CommentsExport.cs
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using Joel.Net;
using zasz.develop.Utils;

namespace zasz.develop.Data
{
    internal class CommentsExport
    {
        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";

        private const string nsCONTENT = "http://purl.org/rss/1.0/modules/content/";
        private const string nsDSQ = "http://www.disqus.com/";
        private const string nsWP = "http://wordpress.org/export/1.0/";
        private const string nsEXCERPT = "http://wordpress.org/export/1.0/excerpt/";
        private const string nsWFW = "http://wellformedweb.org/CommentAPI/";
        private const string nsDC = "http://purl.org/dc/elements/1.1/";
        private readonly Akismet Api;

        private readonly Dictionary<string, string> Namespaces = new Dictionary<string, string>(6);

        private XmlDocument WXR;
        private int _commentCount;

        public CommentsExport()
        {
            Namespaces.Add("wp", nsWP);
            Namespaces.Add("dsq", nsDSQ);
            Namespaces.Add("content", nsCONTENT);
            Namespaces.Add("excerpt", nsEXCERPT);
            Namespaces.Add("wfw", nsWFW);
            Namespaces.Add("dc", nsDC);

            Api = new Akismet("94150f7474ea", "http://www.chandruon.net", "Test/1.0");
            if (!Api.VerifyKey()) throw new Exception("Key not verified");
        }

        public ProgressBar SpamAmount { get; set; }

        public ProgressBar CommentsProgress { get; set; }

        /// <summary>
        ///   Gets Comments out of XML files, which follow the BlogEngine.NET format.
        /// </summary>
        /// <param name = "FolderSystemPath">Folder where XML files are located</param>
        /// <param name = "Log">An action to which logs are sent</param>
        public void ConvertComments(string FolderSystemPath, Action<string> Log)
        {
            Action<string> Die = DieLog =>
                                     {
                                         Log(DieLog);
                                         throw new Death(DieLog);
                                     };

            if (String.IsNullOrEmpty(FolderSystemPath))
                Die("Null Path");

            var Files = Directory.GetFiles(FolderSystemPath);
            var XmlFiles = from AFile in Files
                           where AFile.EndsWith(".xml")
                           select AFile;

            if (XmlFiles.Count() == 0)
                Die("No XML Files found");


            CommentsProgress.Value = 0;
            SpamAmount.Value = 0;
            CommentsProgress.Maximum = 1763;
            SpamAmount.Maximum = 1763;

            WXR = new XmlDocument();
            WXR.AppendChild(WXR.CreateNode(XmlNodeType.XmlDeclaration, null, null));

            var Rss = XElement("rss");
            foreach (var Itm in Namespaces)
                Rss.SetAttribute("xmlns:" + Itm.Key, Itm.Value);

            WXR.AppendChild(Rss);

            var Root = XElement("channel");
            Rss.AppendChild(Root);


            foreach (var PostFile in XmlFiles)
            {
                Log("Working on file : " + PostFile);
                var PostDoc = new XmlDocument();
                PostDoc.Load(PostFile);
                var Title = get(PostDoc, "post/title");
                var Slug = get(PostDoc, "post/slug");
                Log("Title : " + Title);
                var Item = XElement("item");
                Root.AppendChild(Item);

                Item.AppendChild(XElement("title", Title));
                Item.AppendChild(XElement("link", get(PostDoc, "WHAT TO DO HERE?")));
                Item.AppendChild(XElement("dsq:thread_identifier", Slug));
                Item.AppendChild(XElement("wp:post_date_gmt", get(PostDoc, "pubDate")));
                Item.AppendChild(XElement("content:encoded", WXR.CreateCDataSection(get(PostDoc, "content"))));

                Item.AppendChild(XElement("wp:post_id", Slug));
                Item.AppendChild(XElement("wp:comment_status", "open"));
                Item.AppendChild(XElement("wp:ping_status", "open"));
                Item.AppendChild(XElement("wp:post_type", "post"));

                foreach (XmlNode node in PostDoc.SelectNodes("post/comments/comment"))
                {
                    var Comment = new AkismetComment();
                    Comment.Blog = "http://www.chandruon.net/ZaszBlog";
                    Comment.UserIp = get(node, "ip");
                    Comment.CommentContent = get(node, "content");
                    Comment.CommentAuthor = get(node, "author");
                    Comment.CommentAuthorEmail = get(node, "email");
                    Comment.CommentAuthorUrl = get(node, "website");
                    Comment.CommentType = "comment";
                    CommentsProgress.PerformStep();
//                    if (Api.CommentCheck(Comment))
//                    {
//                        SpamAmount.PerformStep();
//                        continue;
//                    }
                    var Cmt = XElement("wp:comment");
                    Cmt.AppendChild(XElement("wp:comment_id", (++_commentCount).ToString()));
                    Cmt.AppendChild(XElement("wp:comment_author", WXR.CreateCDataSection(Comment.CommentAuthor)));
                    Cmt.AppendChild(XElement("wp:comment_author_email", Comment.CommentAuthorEmail));
                    Cmt.AppendChild(XElement("wp:comment_author_url", Comment.CommentAuthorUrl));
                    Cmt.AppendChild(XElement("wp:comment_author_IP", Comment.UserIp));
                    var Date = DateTime.Parse(get(node, "date")).ToString(DATE_FORMAT);
                    Cmt.AppendChild(XElement("wp:comment_date", Date));
                    Cmt.AppendChild(XElement("wp:comment_date_gmt", Date));
                    Cmt.AppendChild(XElement("wp:comment_content", WXR.CreateCDataSection(Comment.CommentContent)));
                    Cmt.AppendChild(XElement("wp:comment_approved", "1"));
                    Item.AppendChild(Cmt);
                }
            }

            WXR.Save(FolderSystemPath + @"\Comments\CommentsWXRAksimetFiltered.xml");
        }

        private static string get(XmlNode Node, string Element)
        {
            var SingleNode = Node.SelectSingleNode(Element);
            return SingleNode == null ? "" : SingleNode.InnerText;
        }


        private XmlElement XElement(string Name, string Value, params XmlAttribute[] Attributes)
        {
            var E = Name.IndexOf(':') != -1
                        ? WXR.CreateElement(Name, Namespaces[Name.Split(':')[0]])
                        : WXR.CreateElement(Name);

            if (Value != null)
                E.InnerText = Value;

            if (Attributes != null)
                foreach (var atr in Attributes)
                    E.Attributes.Append(atr);

            return E;
        }

        private XmlElement XElement(string name)
        {
            return XElement(name, null, (XmlAttribute[]) null);
        }

        private XmlElement XElement(string name, params XmlLinkedNode[] childs)
        {
            XmlElement e;

            if (name.IndexOf(':') != -1)
                e = WXR.CreateElement(name, Namespaces[name.Split(':')[0]]);
            else e = WXR.CreateElement(name);

            if (childs != null)
                foreach (var child in childs)
                    e.AppendChild(child);

            return e;
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