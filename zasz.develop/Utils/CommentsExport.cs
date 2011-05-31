/* 
 * This adapted BlogEngine.NET extension converts the comments into WXR
 * https://github.com/danielHalan/blogengine.net-comments-exporter/blob/master/src/App_Code/Extensions/CommentsExport.cs
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace zasz.develop.Utils
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

        private readonly Dictionary<string, string> _ns = new Dictionary<string, string>(6);

        private int _commentCount;

        private XmlDocument _doc;

        public CommentsExport()
        {
            _ns.Add("wp", nsWP);
            _ns.Add("dsq", nsDSQ);
            _ns.Add("content", nsCONTENT);
            _ns.Add("excerpt", nsEXCERPT);
            _ns.Add("wfw", nsWFW);
            _ns.Add("dc", nsDC);
        }

        /// <summary>
        ///     Gets Comments out of XML files, which follow the BlogEngine.NET format.
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

            string[] Files = Directory.GetFiles(FolderSystemPath);
            IEnumerable<string> XmlFiles = from AFile in Files
                                           where AFile.EndsWith(".xml")
                                           select AFile;

            if (XmlFiles.Count() == 0)
                Die("No XML Files found");

            _doc = new XmlDocument();
            _doc.AppendChild(_doc.CreateNode(XmlNodeType.XmlDeclaration, null, null));

            XmlElement rss = XElement("rss");
            foreach (var itm in _ns)
                rss.SetAttribute("xmlns:" + itm.Key, itm.Value);

            _doc.AppendChild(rss);

            XmlElement root = XElement("channel");
            rss.AppendChild(root);
            int postId = 0;


            foreach (string PostFile in XmlFiles)
            {
                Log("Working on file : " + PostFile);
                var PostDoc = new XmlDocument();
                PostDoc.Load(PostFile);
                string Title = PostDoc.SelectSingleNode("post/title").InnerText;
                string Slug = PostDoc.SelectSingleNode("post/slug").InnerText;
                Log("Title : " + Title);

                // Sub-element: article
                XmlElement item = XElement("item");
                root.AppendChild(item);

                item.AppendChild(XElement("title", Title));
//                item.AppendChild(XElement("link", post.PermaLink.ToString()));
//                item.AppendChild(XElement("pubDate", post.DateCreated.ToString(DATE_FORMAT)));
                item.AppendChild(XElement("dsq:thread_identifier", Slug));
//                item.AppendChild(XElement("dc:creator", "");
//                item.AppendChild(XElement("description", string.Empty));
//                item.AppendChild(XElement("content:encoded", _doc.CreateCDataSection(post.Content)));

                item.AppendChild(XElement("wp:post_id", Slug));
                item.AppendChild(XElement("wp:comment_status", "open"));
                item.AppendChild(XElement("wp:ping_status", "open"));
                item.AppendChild(XElement("wp:post_type", "post"));

                foreach (XmlNode node in PostDoc.SelectNodes("post/comments/comment"))
                {
                    XmlElement cmt = XElement("wp:comment");
                    cmt.AppendChild(XElement("wp:comment_id", (++_commentCount).ToString()));
                    cmt.AppendChild(XElement("wp:comment_author", _doc.CreateCDataSection(get(node, "author"))));
                    cmt.AppendChild(XElement("wp:comment_author_email", get(node, "email")));
                    cmt.AppendChild(XElement("wp:comment_author_url", get(node, "website")));
                    cmt.AppendChild(XElement("wp:comment_author_IP", get(node, "ip")));
                    string Date = DateTime.Parse(get(node, "date")).ToString(DATE_FORMAT);
                    cmt.AppendChild(XElement("wp:comment_date", Date));
                    cmt.AppendChild(XElement("wp:comment_date_gmt", Date));
                    cmt.AppendChild(XElement("wp:comment_content", _doc.CreateCDataSection(get(node, "content"))));
                    cmt.AppendChild(XElement("wp:comment_approved", "1"));
                    item.AppendChild(cmt);
                }
            }

            _doc.Save(FolderSystemPath + @"\CommentsWXR.xml");
        }

        private static string get(XmlNode node, string element)
        {
            XmlNode SingleNode = node.SelectSingleNode(element);
            return SingleNode == null ? "" : SingleNode.InnerText;
        }


        private XmlElement XElement(string name, string value, params XmlAttribute[] attributes)
        {
            XmlElement e;

            if (name.IndexOf(':') != -1)
                e = _doc.CreateElement(name, _ns[name.Split(':')[0]]);
            else e = _doc.CreateElement(name);

            if (value != null)
                e.InnerText = value;

            if (attributes != null)
                foreach (XmlAttribute atr in attributes)
                    e.Attributes.Append(atr);

            return e;
        }

        private XmlElement XElement(string name, params XmlAttribute[] attributes)
        {
            return XElement(name, null, attributes);
        }

        private XmlElement XElement(string name)
        {
            return XElement(name, null, (XmlAttribute[]) null);
        }

        private XmlElement XElement(string name, params XmlLinkedNode[] childs)
        {
            XmlElement e = null;

            if (name.IndexOf(':') != -1)
                e = _doc.CreateElement(name, _ns[name.Split(':')[0]]);
            else e = _doc.CreateElement(name);

            if (childs != null)
                foreach (XmlLinkedNode child in childs)
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