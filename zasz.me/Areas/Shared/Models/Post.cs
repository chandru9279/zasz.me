﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HtmlAgilityPack;

namespace zasz.me.Areas.Shared.Models
{
    public class Post : IModel
    {
        private Site _Site;

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
            get { return Site.WithName(_Site.Name); }
            set { _Site = Site.WithName(value.Name); }
        }


        [NotMapped]
        public string Permalink
        {
            get { return string.Format("http://{0}/Writings/Post/{1}", Site.Host, Slug); }
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
        [Obsolete]
        List<Post> Page(int PageNumber, int PageSize);

        List<Post> Page(int PageNumber, int PageSize, Site ProOrRest);

        Dictionary<int, Dictionary<string, int>> PostedMonthsYearGrouped(Site ProOrRest);

        List<Post> Archive(int Year, int Month, Site ProOrRest);

        int Count(Site ProOrRest);
    }
}