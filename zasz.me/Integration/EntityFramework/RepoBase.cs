using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using zasz.me.Integration.MVC;
using zasz.me.Models;

namespace zasz.me.Integration.EntityFramework
{
    public abstract class RepoBase<Model, NaturalKey> : IRepository<Model, NaturalKey>
        where Model : class, IModel, new()
    {
        protected readonly DbSet<Model> ModelSet;
        protected readonly FullContext Session;

        protected RepoBase(FullContext session)
        {
            Session = session;
            ModelSet = Session.Set<Model>();
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

        public Model Get(NaturalKey naturalKey)
        {
            var naturalKeyEquals = NaturalKeyEquals(naturalKey);
            return ModelSet.Local.Where(naturalKeyEquals.Compile()).FirstOrDefault() ??
                   ModelSet.Where(naturalKeyEquals).FirstOrDefault();
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

        public Expression<Func<Model, bool>> NaturalKeyEquals(NaturalKey id)
        {
            var model = typeof (Model);
            var naturalKey = model.GetProperties().First(x => Attribute.IsDefined(x, typeof(NaturalKeyAttribute)));
            var p = Expression.Parameter(model, "x");
            var modelDotNaturalKey = Expression.Property(p, naturalKey);
            var body = Expression.MakeBinary(ExpressionType.Equal, modelDotNaturalKey, Expression.Constant(id));
            return Expression.Lambda<Func<Model, bool>>(body, p);
        }
    }
}