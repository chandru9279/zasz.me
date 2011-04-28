using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace zasz.me.Models
{
    public class Post : IModel
    {
        public string _SiteName;

        [Key]
        public string Slug { get; set; }

        [Required]
        public string Title { get; set; }

        public string Content { get; set; }

        public ICollection<Tag> Tags { get; set; }

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
    }

    public interface IPostRepository : IRepository<Post>
    {
        List<Post> RecentPosts(int HowMany);

        List<Post> FromTag(string Tag);

        List<Post> Page(int PageNumber, int PageSize);

        List<Post> Page(int PageNumber, int PageSize, Site ProOrRest);

        long Count(Site ProOrRest);
    }
}