using System.ComponentModel.DataAnnotations;

namespace zasz.me.Models
{
    public class Tag
    {
        public Tag(string TagName)
        {
            Name = TagName;
        }

        [Key]
        public string Name { get; set; }
    }
}