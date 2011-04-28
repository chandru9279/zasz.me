using System;
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
                    where Model.Tags.Any(EntryTag => EntryTag.Name == Tag)
                    select Model).ToList();
        }

        public List<Post> Page(int PageNumber, int PageSize)
        {
            return _ModelSet.OrderBy(Model => Model.Timestamp).Skip(PageNumber * PageSize).Take(PageSize).ToList();
        }

        public List<Post> Page(int PageNumber, int PageSize, Site ProOrRest)
        {
            return (from Model in _ModelSet
                    where Model.Site.Name == ProOrRest.Name || Model.Site.Name == "Both"
                    orderby Model.Timestamp
                    select Model).Skip(PageNumber * PageSize).Take(PageSize).ToList(); 
        }

        public long Count(Site ProOrRest)
        {
            return _ModelSet.Where(Model => Model.Site.Name == ProOrRest.Name || Model.Site.Name == "Both").Count();
        }

        #endregion
    }
}