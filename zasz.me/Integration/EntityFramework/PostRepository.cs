using System.Collections.Generic;
using System.Linq;
using zasz.me.Models;

namespace zasz.me.Integration.EntityFramework
{
    public class PostRepository : Repository<Post, string>, IPostRepository
    {
        public PostRepository(FullContext context)
            : base(context)
        {
        }

        protected override IOrderedQueryable<Post> Ordering(IQueryable<Post> queryable)
        {
            return queryable.OrderByDescending(model => model.Timestamp);
        }

        #region IPostRepository Members

        public Paged<Post> Page(Tag tag, int pageNumber, int pageSize)
        {
            return PageQuery(Context.Entry(tag).Collection(x => x.Posts).Query().OrderByDescending(model => model.Timestamp), pageNumber, pageSize);
        }

        public List<Post> Archive(int year, int month)
        {
            return (from model in Set
                    where model.Timestamp.Year == year && model.Timestamp.Month == month
                    select model).ToList();
        }

        /// <returns> A Dictionary of year as Key and the list of formatted months on which posts have been published as value</returns>
        public Dictionary<int, Dictionary<string, int>> PostedMonthsYearGrouped()
        {
            var dates = (from model in Set
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