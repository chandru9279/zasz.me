using System.Collections.Generic;
using System.Linq;
using zasz.me.Models;

namespace zasz.me.Integration.EntityFramework
{
    public class TagRepository : Repository<Tag, string>, ITagRepository
    {
        public TagRepository(FullContext context) : base(context)
        {
        }

        #region ITagRepository Members
        
        public Dictionary<string, int> WeightedList()
        {
            return (from tag in Context.Tags
                    let count = tag.Posts.Count()
                    where count > 0
                    select new { tag.Name, count }).ToDictionary(x => x.Name, x => x.count);
        }

        #endregion
    }
}