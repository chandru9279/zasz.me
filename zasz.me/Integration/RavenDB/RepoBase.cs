using System.Collections.Generic;
using System.Linq;
using Raven.Client;
using zasz.me.Models;

namespace zasz.me.Integration.RavenDB
{
    public class RepoBase<Model> : IRepository<Model>
    {
        protected readonly IDocumentStore _Store;

        public RepoBase(IDocumentStore Store)
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

        public void Delete(Model Entity)
        {
            using (var Session = _Store.OpenSession())
            {
                _Store.Conventions.GetIdentityProperty(typeof(Model)).GetValue(Entity)
                Session.Delete(Entity);
                Session.SaveChanges();
            }
        }

        public List<Model> All()
        {
            using (var Session = _Store.OpenSession())
            {
                return Session.Query<Model>().ToList();
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