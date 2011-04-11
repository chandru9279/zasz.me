using System.Collections.Generic;
using System.Linq;
using Raven.Client;
using zasz.me.Models;

namespace zasz.me.Integration.RavenDB
{
    public abstract class RepoBase<Model> : IRepository<Model> where Model : IModel
    {
        protected readonly IDocumentSession _Session;

        protected RepoBase(IDocumentSession Session)
        {
            _Session = Session;
        }

        #region IRepository<Model> Members

        public void Save(Model Instance)
        {
            _Session.Store(Instance);
        }

        public Model Get(string ID)
        {
            return _Session.Load<Model>(ID);
        }

        public void Delete(Model Entity)
        {
            _Session.Delete(Entity);
        }

        public List<Model> Page(int PageNumber, int PageSize)
        {
            return _Session.Load<Model>().Skip(PageNumber * PageSize).Take(PageSize).ToList();
        }

        public long Count()
        {
            return _Session.Load<Model>().Count();
        }

        /// <summary>
        /// Calling Flush in any repository is the same thing as calling flush for the whole Web Request.
        /// It saves changes to all Models, Not only for this specific Model.
        /// </summary>
        public void Flush()
        {
            _Session.SaveChanges();
        }

        #endregion
    }
}