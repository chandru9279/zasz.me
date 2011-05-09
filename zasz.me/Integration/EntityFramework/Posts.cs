using System;
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
            var PersistantTags = new List<Tag>(Instance.Tags.Count);
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
            return _ModelSet.OrderBy(Model => Model.Timestamp).Skip(PageNumber*PageSize).Take(PageSize).ToList();
        }

        /// <param name="PageNumber">Zero-Based Index</param>
        public List<Post> Page(int PageNumber, int PageSize, Site ProOrRest)
        {
            return (from Model in _ModelSet
                    where Model.Site.Name == ProOrRest.Name || Model.Site.Name == "Both"
                    orderby Model.Timestamp
                    select Model).Skip(PageNumber*PageSize).Take(PageSize).ToList();
        }

        public int Count(Site ProOrRest)
        {
            return _ModelSet.Where(Model => Model.Site.Name == ProOrRest.Name || Model.Site.Name == "Both").Count();
        }

        #endregion

        /// <returns> A Dictionary of year as Key and the list of formatted months on which posts have been published as value</returns>
        public Dictionary<int, List<string>> PostedMonths(Site ProOrRest)
        {
            Dictionary<int, List<string>> Result = new Dictionary<int, List<string>>();
            IQueryable<DateTime> Dates = (from Model in _ModelSet
                                          where Model.Site.Name == ProOrRest.Name || Model.Site.Name == "Both"
                                          select Model.Timestamp);
            Dictionary<DateTime, string> Dict = Dates.ToDictionary(It => new DateTime(It.Year, It.Month, 1), It => string.Format("{0:MMMM, yyyy}", It));
            var a = from Pair in Dict.Distinct(new FormattedDateComparator())
                    group Pair by Pair.Key.Year into Group
                    select new {Group.Key, Group};
            foreach (var Pair in Dict.Distinct(new FormattedDateComparator()).OrderBy(It => It.Key).GroupBy(It => It.Key.Year))
            {
                Result.Add(Pair.Key, Pair.ToList());
            }
        }

        #region Nested type: FormattedDateComparator

        private class FormattedDateComparator : IEqualityComparer<KeyValuePair<DateTime, string>>
        {
            #region IEqualityComparer<KeyValuePair<DateTime,string>> Members

            public bool Equals(KeyValuePair<DateTime, string> X, KeyValuePair<DateTime, string> Y)
            {
                return X.Value == Y.Value;
            }

            public int GetHashCode(KeyValuePair<DateTime, string> Obj)
            {
                return Obj.GetHashCode();
            }

            #endregion
        }

        #endregion
    }
}