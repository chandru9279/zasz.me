using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HtmlAgilityPack;

namespace zasz.me.Models
{
    public class Post : IModel
    {
        private string _SiteName;

        [Key]
        public string Slug { get; set; }

        [Required]
        public string Title { get; set; }

        public string Content { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        [Required]
        public Site Site
        {
            get { return Site.WithName(_SiteName); }
            set { _SiteName = value.Name; }
        }


        [NotMapped]
        public string Permalink
        {
            get { return string.Format("http://{0}/{1}/post/{2}", Site.Host, Site.Name, Slug); }
        }

        public string GetDescription(int Threshold)
        {
            HtmlDocument Doc = new HtmlDocument();
            Doc.LoadHtml(Content);
            var Description = String.Empty;
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

    public interface IPostRepository : IRepository<Post>
    {
        List<Post> RecentPosts(int HowMany);

        List<Post> Page(int PageNumber, int PageSize);

        List<Post> Page(int PageNumber, int PageSize, Site ProOrRest);

        long Count(Site ProOrRest);
    }
}