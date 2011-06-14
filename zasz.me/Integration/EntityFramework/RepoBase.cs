using System;
using System.Data.Entity;
using System.Linq;
using zasz.me.Areas.Shared.Models;

namespace zasz.me.Integration.EntityFramework
{
    public abstract class RepoBase<Model, NaturalKeyType> : IRepository<Model, NaturalKeyType> where Model : class, IModel<Model, NaturalKeyType>, new()
    {
        protected readonly DbSet<Model> _ModelSet;
        protected readonly FullContext _Session;

        protected RepoBase(FullContext Session)
        {
            _Session = Session;
            _ModelSet = _Session.Set<Model>();
        }

        #region IRepository<Model> Members

        public virtual Model Save(Model Instance)
        {
            return _ModelSet.Add(Instance);
        }

        /// <summary>
        /// When a model does not have a natural key, then Load() & Get() has the same functionality.
        /// </summary>
        public Model Load(Guid Id)
        {
            return _ModelSet.Find(Id);
        }

        public void Delete(Model Entity)
        {
            _ModelSet.Remove(Entity);
        }

        public long Count()
        {
            return _ModelSet.Count();
        }

        public Model Get(NaturalKeyType MainProperty)
        {
            return _ModelSet.Where(new Model().NaturalEquals(MainProperty)).FirstOrDefault();
        }

        /// <summary>
        ///     Calling Commit in any repository is the same thing as calling commit for the whole Web Request.
        ///     It saves changes to all Models, Not only for this specific Model.
        /// </summary>
        public void Commit()
        {
            _Session.SaveChanges();
        }

        #endregion
    }
}