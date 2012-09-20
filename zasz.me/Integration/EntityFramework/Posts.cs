using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using zasz.me.Models;

namespace zasz.me.Integration.EntityFramework
{
    public class Posts : RepoBase<Post, string>, IPostRepository
    {
        public Posts(FullContext session)
            : base(session)
        {
        }

        #region IPostRepository Members

        public List<Post> Page(int pageNumber, int pageSize)
        {
            return ModelSet.OrderByDescending(model => model.Timestamp)
                .Skip(pageNumber*pageSize)
                .Take(pageSize).ToList();
        }

        public List<Post> Archive(int year, int month)
        {
            return (from model in ModelSet
                    where model.Timestamp.Year == year && model.Timestamp.Month == month
                    select model).ToList();
        }

        /// <returns> A Dictionary of year as Key and the list of formatted months on which posts have been published as value</returns>
        public Dictionary<int, Dictionary<string, int>> PostedMonthsYearGrouped()
        {
            var dates = (from model in ModelSet
                         select model.Timestamp).ToList();

            var groupingByYear = from date in dates
                                 orderby date.Year descending
                                 group date by date.Year
                                 into yearGroup
                                 select new
                                            {
                                                Year = yearGroup.Key,
                                                Formatted = from date in yearGroup
                                                            orderby date.Month descending
                                                            group date by date.Month
                                                            into monthGroup
                                                            select new
                                                                       {
                                                                           DateString =
                                                                string.Format("{0:MMMM yyyy}", monthGroup.First()),
                                                                           Count = monthGroup.Count()
                                                                       }
                                            };

            return groupingByYear.ToDictionary(x => x.Year,
                                               x => x.Formatted.ToDictionary(
                                                   month => month.DateString,
                                                   month => month.Count
                                                        ));
        }

        #endregion
    }
}