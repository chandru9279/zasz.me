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

        public List<Post> Page(int PageNumber, int PageSize)
        {
            return _ModelSet.OrderBy(Model => Model.Timestamp).Skip(PageNumber * PageSize).Take(PageSize).ToList();
        }

        /// <param name = "PageNumber">Zero-Based Index</param>
        public List<Post> Page(int PageNumber, int PageSize, Site ProOrRest)
        {
            return (from Model in _ModelSet
                    where Model.Site.Name == ProOrRest.Name || Model.Site.Name == "Both"
                    orderby Model.Timestamp
                    select Model).Skip(PageNumber * PageSize).Take(PageSize).ToList();
        }

        public List<Post> Archive(int Year, int Month, Site ProOrRest)
        {
            return (from Model in _ModelSet
                    where (Model.Site.Name == ProOrRest.Name || Model.Site.Name == "Both")
                    && Model.Timestamp.Year == Year && Model.Timestamp.Month == Month
                    select Model).ToList();
        }

        public int Count(Site ProOrRest)
        {
            return _ModelSet.Where(Model => Model.Site.Name == ProOrRest.Name || Model.Site.Name == "Both").Count();
        }

        /// <returns> A Dictionary of year as Key and the list of formatted months on which posts have been published as value</returns>
        public Dictionary<int, Dictionary<string, int>> PostedMonthsYearGrouped(Site ProOrRest)
        {
            var Dates = (from Model in _ModelSet
                         where Model.Site.Name == ProOrRest.Name || Model.Site.Name == "Both"
                         select Model.Timestamp).ToList();

            var GroupingByYear = from Date in Dates
                                 orderby Date.Year descending 
                                 group Date by Date.Year
                                 into YearGroup 
                                 select new
                                            {
                                                Year = YearGroup.Key,
                                                Formatted = from Date in YearGroup
                                                            orderby Date.Month descending
                                                            group Date by Date.Month
                                                            into MonthGroup
                                                            select new
                                                                       {
                                                                           DateString = string.Format("{0:MMMM yyyy}", MonthGroup.First()),
                                                                           Count = MonthGroup.Count()
                                                                       }
                                            };

            return GroupingByYear.ToDictionary(It => It.Year, It => It.Formatted.ToDictionary(Month => Month.DateString, Month => Month.Count));
        }

        #endregion
    }
}