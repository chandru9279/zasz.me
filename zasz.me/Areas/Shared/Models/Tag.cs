using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace zasz.me.Areas.Shared.Models
{
    public class Tag : IModel
    {
        public Tag(string TagName)
        {
            Name = TagName;
        }

        public Tag()
        {
        }

        [Key]
        public string Name { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }

    public interface ITagRepository : IRepository<Tag>
    {
        List<Post> PagePosts(string Tag, int PageNumber, int MaxPostsPerPage, Site ProOrRest);

        int CountPosts(string Tag, Site ProOrRest);
    }
}