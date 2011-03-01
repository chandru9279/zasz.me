using System.Linq;
using Raven.Client.Document;
using zasz.me.Models;

namespace zasz.me.Integration.RavenDB
{
    public class RepoBase<Model> : IRepository<Model>
    {
        protected readonly DocumentStore _Store;

        public RepoBase(DocumentStore Store)
        {
            _Store = Store;
        }

        #region IRepository<Model> Members

        public void Save(Model Instance)
        {
            using (var Session = _Store.OpenSession())
            {
                Session.Store(Instance);
                Session.SaveChanges();
            }
        }

        public Model Get(string ID)
        {
            using (var Session = _Store.OpenSession())
            {
                return Session.Load<Model>(ID);
            }
        }

        public void Delete(int ID)
        {
            using (var Session = _Store.OpenSession())
            {
                Session.Delete(ID);
                Session.SaveChanges();
            }
        }

        public IQueryable<Model> All()
        {
            using (var Session = _Store.OpenSession())
            {
                return Session.Load<Model>().AsQueryable();
            }
        }

        public long Count()
        {
            using (var Session = _Store.OpenSession())
            {
                return Session.Query<Model>().Count();
            }
        }

        #endregion
    }
}