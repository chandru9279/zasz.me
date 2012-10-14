using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web.Mvc;
using HtmlAgilityPack;
using SolrNet.Attributes;
using zasz.me.Controllers.Utils;
using zasz.me.Integration.MVC;

namespace zasz.me.Models
{
    [Table("Posts", Schema = "Blog")]
    public class Post : IModel
    {
        [Required]
        [SolrField("Post_Slug")]
        [NaturalKey]
        public string Slug { get; set; }

        [Required]
        [SolrField("Post_Title")]
        public string Title { get; set; }

        [SolrField("Post_Content")]
        public string Content { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        [NotMapped]
        public string TagsLine
        {
            get { return Tags == null ? "" : string.Join(" ", TagStrings); }
        }

        [RequiredDatetime]
        public DateTime Timestamp { get; set; }

        [SolrField("Post_Tags")]
        public virtual List<string> TagStrings
        {
            get { return Tags.Select(x => x.Name).ToList(); }
            set { Tags = value.Select(x => new Tag { Name = x }).ToList(); }
        }

        #region IModel Members

        [Key]
        [SolrUniqueKey("Id")]
        public Guid Id { get; set; }

        #endregion

        public string ThumbnailLink(UrlHelper url)
        {
            return string.Format("{0}{1}/{2}", Handy.BaseUrl(), url.Action("Thumbnail", "Blog"), Slug);
        }

        public string Permalink(UrlHelper url)
        {
            return string.Format("{0}{1}/{2}", Handy.BaseUrl(), url.Action("Post", "Blog"), Slug);
        }

        public string GetDescription(int threshold)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(Content);
            var description = String.Empty;
            ProcessNode(doc.DocumentNode, ref description, threshold);
            return description;
        }

        private static void ProcessNode(HtmlNode node, ref string description, int threshold)
        {
            foreach (var childNode in node.ChildNodes)
            {
                if (childNode is HtmlTextNode)
                {
                    description += childNode.InnerText.Trim();
                    if (description.Length >= threshold)
                    {
                        description = description.Substring(0, threshold) + "...";
                        break;
                    }
                }
                else ProcessNode(childNode, ref description, threshold);
            }
        }
    }

    public interface IPostRepository : IRepository<Post, string>
    {
        Paged<Post> Page(Tag tag, int pageNumber, int pageSize);

        Dictionary<int, Dictionary<string, int>> PostedMonthsYearGrouped();

        List<Post> Archive(int year, int month);

        void DeleteAll();
    }
}