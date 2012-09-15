using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using zasz.me.Models;

namespace zasz.me.Integration.EntityFramework
{
    public class Tags : RepoBase<Tag, string>, ITagRepository
    {
        public Tags(FullContext session) : base(session)
        {
        }

        #region ITagRepository Members

        public List<Post> PagePosts(string tag, int page, int postsPerPage)
        {
            return Get(tag).Posts.Skip(page*postsPerPage).Take(postsPerPage).ToList();
        }

        public int CountPosts(string tag)
        {
            return Get(tag).Posts.Count();
        }

        public Dictionary<string, int> WeightedList()
        {
            return (from tag in Session.Tags
                    let count = tag.Posts.Count()
                    where count > 0
                    select new {tag.Name, count}).ToDictionary(x => x.Name, x => x.count);
        }

        #endregion

        public override Expression<Func<Tag, bool>> NaturalKeyComparison(string slug)
        {
            return x => x.Name == slug;
        }
    }
}