using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace zasz.me.Areas.Shared.Models
{
    public class Tag : IModel<Tag, string>
    {
        public Tag(string TagName)
        {
            Name = TagName;
        }

        public Tag()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        #region IModel<Tag,string> Members

        public Func<Tag, bool> NaturalEquals(string TagName)
        {
            return It => It.Name == TagName;
        }

        #endregion
    }

    public interface ITagRepository : IRepository<Tag, string>
    {
        List<Post> PagePosts(string Tag, int PageNumber, int MaxPostsPerPage, Site ProOrRest);

        int CountPosts(string Tag, Site ProOrRest);

        Dictionary<string, int> WeightedList(Site Site);
    }
}