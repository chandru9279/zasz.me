using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using zasz.me.Areas.Shared.Models;

namespace zasz.me.Integration.EntityFramework
{
    public abstract class RepoBase<Model, NaturalKey> : IRepository<Model, NaturalKey> where Model : class, IModel, new()
    {
        protected readonly DbSet<Model> _ModelSet;
        protected readonly FullContext _Session;

        protected RepoBase(FullContext Session)
        {
            _Session = Session;
            _ModelSet = _Session.Set<Model>();
        }

        #region IRepository<ModelType> Members

        public virtual Model Save(Model Instance)
        {
            if (Guid.Empty == Instance.Id) Instance.Id = Guid.NewGuid();
            return _ModelSet.Add(Instance);
        }

        /// <summary>
        /// When a model does not have a natural key, then Load() & Get() has the same functionality.
        /// </summary>
        public Model Load(Guid Id)
        {
            return _ModelSet.Find(Id);
        }

        public abstract Expression<Func<Model, bool>> NaturalKeyComparison(NaturalKey MainProperty);

        public Model Get(NaturalKey NaturalKey)
        {
            return _ModelSet.Local.Where(NaturalKeyComparison(NaturalKey).Compile()).FirstOrDefault() ??
            _ModelSet.Where(NaturalKeyComparison(NaturalKey)).FirstOrDefault();
        }

        public void Delete(Model Entity)
        {
            _ModelSet.Remove(Entity);
        }

        public long Count()
        {
            return _ModelSet.Count();
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