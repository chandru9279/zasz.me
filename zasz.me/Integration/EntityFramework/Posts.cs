using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using zasz.me.Shared.Models;

namespace zasz.me.Integration.EntityFramework
{
    /* This condition occurs everywhere, instead of being pushed into the Post or Site
     * Domain itself, because EF4 cant convert it to SQL if it is so extracted into a 
     * method  :
     * EachPost.Site.Name == ProOrRest.Name || EachPost.Site.Name == Site.SHARED*/

    public class Posts : RepoBase<Post, string>, IPostRepository
    {
        public Posts(FullContext Session)
            : base(Session)
        {
        }

        #region IPostRepository Members

        public List<Post> Page(int PageNumber, int PageSize)
        {
            return _ModelSet.OrderByDescending(Model => Model.Timestamp)
                .Skip(PageNumber*PageSize)
                .Take(PageSize).ToList();
        }

        /// <param name = "PageNumber">Zero-Based Index</param>
        public List<Post> Page(int PageNumber, int PageSize, Site ProOrRest)
        {
            return (from Model in _ModelSet
                    where Model.Site.Name == ProOrRest.Name || Model.Site.Name == Site.SHARED
                    orderby Model.Timestamp descending
                    select Model).Skip(PageNumber*PageSize).Take(PageSize).ToList();
        }

        public List<Post> Archive(int Year, int Month, Site ProOrRest)
        {
            return (from Model in _ModelSet
                    where (Model.Site.Name == ProOrRest.Name || Model.Site.Name == Site.SHARED)
                          && Model.Timestamp.Year == Year && Model.Timestamp.Month == Month
                    select Model).ToList();
        }

        public int Count(Site ProOrRest)
        {
            return _ModelSet.Where(Model => Model.Site.Name == ProOrRest.Name || Model.Site.Name == Site.SHARED).Count();
        }

        /// <returns> A Dictionary of year as Key and the list of formatted months on which posts have been published as value</returns>
        public Dictionary<int, Dictionary<string, int>> PostedMonthsYearGrouped(Site ProOrRest)
        {
            var Dates = (from Model in _ModelSet
                         where Model.Site.Name == ProOrRest.Name || Model.Site.Name == Site.SHARED
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
                                                                           DateString =
                                                                string.Format("{0:MMMM yyyy}", MonthGroup.First()),
                                                                           Count = MonthGroup.Count()
                                                                       }
                                            };

            return GroupingByYear.ToDictionary(It => It.Year,
                                               It =>
                                               It.Formatted.ToDictionary(Month => Month.DateString, Month => Month.Count));
        }

        #endregion

        public override Expression<Func<Post, bool>> NaturalKeyComparison(string Slug)
        {
            return It => It.Slug == Slug;
        }
    }
}