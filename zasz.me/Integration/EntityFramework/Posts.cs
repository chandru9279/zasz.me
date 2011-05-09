using System.Collections.Generic;
using System.Linq;
using zasz.me.Areas.Shared.Models;

namespace zasz.me.Integration.EntityFramework
{
    public class Posts : RepoBase<Post>, IPostRepository
    {
        private readonly ITagRepository _Tags;

        public Posts(FullContext Session, ITagRepository Tags)
            : base(Session)
        {
            _Tags = Tags;
        }

        #region IPostRepository Members

        public override void Save(Post Instance)
        {
            List<Tag> PersistantTags = new List<Tag>(Instance.Tags.Count);
            PersistantTags.AddRange(from Tag in Instance.Tags
                                    select _Tags.FindOrNew(Tag.Name));
            Instance.Tags = PersistantTags;
            base.Save(Instance);
        }

        public List<Post> RecentPosts(int HowMany)
        {
            return (from Model in _ModelSet
                    orderby Model.Timestamp descending
                    select Model).Take(HowMany).ToList();
        }

        public List<Post> Page(int PageNumber, int PageSize)
        {
            return _ModelSet.OrderBy(Model => Model.Timestamp).Skip(PageNumber * PageSize).Take(PageSize).ToList();
        }

        /// <param name="PageNumber">Zero-Based Index</param>
        public List<Post> Page(int PageNumber, int PageSize, Site ProOrRest)
        {
            return (from Model in _ModelSet
                    where Model.Site.Name == ProOrRest.Name || Model.Site.Name == "Both"
                    orderby Model.Timestamp
                    select Model).Skip(PageNumber * PageSize).Take(PageSize).ToList();
        }

        public int Count(Site ProOrRest)
        {
            return _ModelSet.Where(Model => Model.Site.Name == ProOrRest.Name || Model.Site.Name == "Both").Count();
        }

        #endregion
    }
}