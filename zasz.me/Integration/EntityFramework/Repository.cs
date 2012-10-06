using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using zasz.me.Integration.MVC;
using zasz.me.Models;

namespace zasz.me.Integration.EntityFramework
{
    public class Repository<Model, NaturalKey> : IRepository<Model, NaturalKey>
        where Model : class, IModel, new()
    {
        protected readonly DbSet<Model> Set;
        protected readonly FullContext Context;

        protected Repository(FullContext context)
        {
            Context = context;
            Set = Context.Set<Model>();
        }

        #region IRepository<Model,NaturalKey> Members

        public virtual Model Save(Model instance)
        {
            if (Guid.Empty == instance.Id) instance.Id = Guid.NewGuid();
            return Set.Add(instance);
        }

        /// <summary>
        /// When a model does not have a natural key, then Load() & Get() has the same functionality.
        /// </summary>
        public Model Load(Guid id)
        {
            return Set.Find(id);
        }

        public Model Get(NaturalKey naturalKey)
        {
            var naturalKeyEquals = NaturalKeyEquals(naturalKey);
            return Set.Local.Where(naturalKeyEquals.Compile()).FirstOrDefault() ??
                   Set.Where(naturalKeyEquals).FirstOrDefault();
        }

        public void Delete(Model entity)
        {
            Set.Remove(entity);
        }

        public long Count()
        {
            return Set.Count();
        }

        public virtual Paged<Model> Page(int pageNumber, int pageSize)
        {
            return PageQuery(Set, pageNumber, pageSize);
        }
        
        protected Paged<Model> PageQuery(IQueryable<Model> query, int pageNumber, int pageSize)
        {
            var caches = query.Skip(pageNumber * pageSize).Take(pageSize).ToList();
            var count = query.Count();
            return new Paged<Model> { Set = caches, NumberOfPages = (int)Math.Ceiling(count / (double)pageSize), PageSize = pageSize, PageNumber = pageNumber };
        }
        
        /// <summary>
        ///     Calling Commit in any repository is the same thing as calling commit for the whole Web Request.
        ///     It saves changes to all Models, Not only for this specific Model.
        /// </summary>
        public void Commit()
        {
            Context.SaveChanges();
        }
        
        /// <summary>
        ///     Child repos can use this to do DB work, and at the end of it dispose the context full
        ///     of objects. It uses Activator.CreateInstance instead of plain old "new" to work with
        ///     test database in integration tests. No hit in performance etc. 
        /// </summary>
        /// <param name="work"> The closure that contains the work logic </param>
        protected void UnitOfWork(Action<FullContext> work)
        {
            using (var batchContext = (FullContext)Activator.CreateInstance(Context.GetType()))
            {
                work(batchContext);
            }
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