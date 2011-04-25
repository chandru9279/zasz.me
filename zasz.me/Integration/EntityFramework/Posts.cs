using System.Collections.Generic;
using System.Linq;
using zasz.me.Models;

namespace zasz.me.Integration.EntityFramework
{
    public class Posts : RepoBase<Post>, IPostRepository
    {
        public Posts(FullContext Session)
            : base(Session)
        {
        }

        #region IPostRepository Members

        public List<Post> RecentPosts(int HowMany)
        {
            return (from Model in _ModelSet
                    orderby Model.Timestamp descending
                    select Model).Take(HowMany).ToList();
        }

        public List<Post> FromTag(string Tag)
        {
            return (from Model in _ModelSet
                    where Model.Tags.Any(EntryTag => EntryTag == Tag)
                    select Model).ToList();
        }

        public List<Post> Page(int PageNumber, int PageSize)
        {
            return _ModelSet.OrderBy(Model => Model.Timestamp).Skip(PageNumber * PageSize).Take(PageSize).ToList();
        }

        #endregion
    }
}