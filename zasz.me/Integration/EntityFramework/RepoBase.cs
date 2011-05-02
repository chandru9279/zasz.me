﻿using System.Data.Entity;
using System.Linq;
using zasz.me.Models;

namespace zasz.me.Integration.EntityFramework
{
    public abstract class RepoBase<Model> : IRepository<Model> where Model : class, IModel
    {
        protected readonly DbSet<Model> _ModelSet;
        protected readonly FullContext _Session;

        protected RepoBase(FullContext Session)
        {
            _Session = Session;
            _ModelSet = _Session.Set<Model>();
        }

        #region IRepository<Model> Members

        public virtual void Save(Model Instance)
        {
            _ModelSet.Add(Instance);
        }

        public Model Get(string Id)
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