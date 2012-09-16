using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using HtmlAgilityPack;
using SolrNet.Attributes;

namespace zasz.me.Models
{
    public class Post : IModel
    {
        [Required]
        [SolrField("Post_Slug")]
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

        [Required]
        public DateTime Timestamp { get; set; }

        [NotMapped]
        public string Permalink
        {
            get { return string.Format("http://zasz.me/Blog/Post/{0}", Slug); }
        }

        [SolrField("Post_Tags")]
        public virtual List<string> TagStrings
        {
            get { return Tags.Select(x => x.Name).ToList(); }
            set { Tags = value.Select(x => new Tag {Name = x}).ToList(); }
        }

        #region IModel Members

        [Key]
        [SolrUniqueKey("Id")]
        public Guid Id { get; set; }

        #endregion

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
        List<Post> Page(int pageNumber, int pageSize);

        Dictionary<int, Dictionary<string, int>> PostedMonthsYearGrouped();

        List<Post> Archive(int year, int month);
    }
}