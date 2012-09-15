using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using zasz.me.Models;

namespace zasz.me.Integration.EntityFramework
{
    public abstract class RepoBase<Model, NaturalKey> : IRepository<Model, NaturalKey>
        where Model : class, IModel, new()
    {
        protected readonly DbSet<Model> ModelSet;
        protected readonly FullContext Session;

        protected RepoBase(FullContext Session)
        {
            this.Session = Session;
            ModelSet = this.Session.Set<Model>();
        }

        #region IRepository<Model,NaturalKey> Members

        public virtual Model Save(Model instance)
        {
            if (Guid.Empty == instance.Id) instance.Id = Guid.NewGuid();
            return ModelSet.Add(instance);
        }

        /// <summary>
        /// When a model does not have a natural key, then Load() & Get() has the same functionality.
        /// </summary>
        public Model Load(Guid id)
        {
            return ModelSet.Find(id);
        }

        public Model Get(NaturalKey mainProperty)
        {
            return ModelSet.Local.Where(NaturalKeyComparison(mainProperty).Compile()).FirstOrDefault() ??
                   ModelSet.Where(NaturalKeyComparison(mainProperty)).FirstOrDefault();
        }

        public void Delete(Model entity)
        {
            ModelSet.Remove(entity);
        }

        public long Count()
        {
            return ModelSet.Count();
        }

        /// <summary>
        ///     Calling Commit in any repository is the same thing as calling commit for the whole Web Request.
        ///     It saves changes to all Models, Not only for this specific Model.
        /// </summary>
        public void Commit()
        {
            Session.SaveChanges();
        }

        #endregion

        public abstract Expression<Func<Model, bool>> NaturalKeyComparison(NaturalKey slug);
    }
}