using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using zasz.me.Integration.MVC;

namespace zasz.me.Models
{
    [Table("Tags", Schema = "Blog")]
    public class Tag : IModel
    {
        public Tag(string tagName)
        {
            Name = tagName;
        }

        public Tag()
        {
        }

        [NaturalKey]
        public string Name { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        #region IModel Members

        [Key]
        public Guid Id { get; set; }

        #endregion
    }

    public interface ITagRepository : IRepository<Tag, string>
    {
        Dictionary<string, int> WeightedList();
    }
}