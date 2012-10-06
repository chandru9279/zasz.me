using System;
using System.Linq;
using zasz.me.Models;

namespace zasz.me.Integration.EntityFramework
{
    public class AnswerRepository : Repository<Answer, Guid>, IAnswerRepository
    {
        protected AnswerRepository(FullContext context) : base(context)
        {
        }

        public Paged<Answer> Page(Cache cache, int pageNumber, int pageSize)
        {
            return PageQuery(Set.Where(x => x.Cache.Id == cache.Id), pageNumber, pageSize);
        }
    }

    public interface IAnswerRepository
    {
        Paged<Answer> Page(Cache cache, int pageNumber, int pageSize);
    }
}