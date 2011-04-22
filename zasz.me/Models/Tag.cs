using System.ComponentModel.DataAnnotations;

namespace zasz.me.Models
{
    public class Tag
    {
        [Key]
        public string Name { get; set; }
    }
}