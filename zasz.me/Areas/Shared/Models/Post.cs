using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using HtmlAgilityPack;
using SolrNet.Attributes;

namespace zasz.me.Areas.Shared.Models
{
    public class Post : IModel
    {
        private Site _Site = Site.Shared;

        [Key]
        [SolrUniqueKey("Id")]
        public Guid Id { get; set; }

        [Required]
        [SolrField("Post_Slug")]
        public string Slug { get; set; }

        [Required]
        [SolrField("Post_Title")]
        public string Title { get; set; }

        [SolrField("Post_Content")]
        public string Content { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        [SolrField("Post_Tags")]
        public virtual List<string> TagStrings { get { return Tags.Select(x => x.Name).ToList(); } }

        [NotMapped]
        public string TagsLine
        {
            get { return Tags == null ? "" : string.Join(" ", TagStrings); }
        }


        [Required]
        public DateTime Timestamp { get; set; }

        [Required]
        public Site Site
        {
            get { return Site.With(_Site.Name); }
            set { _Site = Site.With(value.Name); }
        }


        [NotMapped]
        public string Permalink
        {
            get { return string.Format("http://{0}/Blog/Post/{1}", Site.Host, Slug); }
        }

        public string GetDescription(int Threshold)
        {
            var Doc = new HtmlDocument();
            Doc.LoadHtml(Content);
            string Description = String.Empty;
            ProcessNode(Doc.DocumentNode, ref Description, Threshold);
            return Description;
        }

        private static void ProcessNode(HtmlNode Node, ref string Description, int Threshold)
        {
            foreach (HtmlNode ChildNode in Node.ChildNodes)
            {
                if (ChildNode is HtmlTextNode)
                {
                    Description += ChildNode.InnerText.Trim();
                    if (Description.Length >= Threshold)
                    {
                        Description = Description.Substring(0, Threshold) + "...";
                        break;
                    }
                }
                else ProcessNode(ChildNode, ref Description, Threshold);
            }
        }
    }

    public interface IPostRepository : IRepository<Post, string>
    {
        List<Post> Page(int PageNumber, int PageSize);

        List<Post> Page(int PageNumber, int PageSize, Site ProOrRest);

        Dictionary<int, Dictionary<string, int>> PostedMonthsYearGrouped(Site ProOrRest);

        List<Post> Archive(int Year, int Month, Site ProOrRest);

        int Count(Site ProOrRest);
    }
}