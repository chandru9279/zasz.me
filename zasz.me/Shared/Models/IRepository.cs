using System;
using System.Linq.Expressions;

namespace zasz.me.Areas.Shared.Models
{
    /// <summary>
    ///     This is the base interface of all Repositories. In this App there's no seperate Service Layer that accesses 
    ///     the CRUD only Repository Layer that hides the actual DB. They are combined into one - Each Repo has the usual CRUD methods
    ///     and intelligent Domain Specific methods that often use the CRUD ones. 
    /// 
    ///     This is not meant to be implemented directly - Only sub-interfaces are Expected to have implementations
    /// </summary>
    /// <typeparam name = "Model">The Model for which the implementation is the Repository</typeparam>
    public interface IRepository<Model, NaturalKeyType> where Model : IModel
    {
        Model Save(Model Instance);

        Model Load(Guid Id);

        Model Get(NaturalKeyType MainProperty);

        void Delete(Model Entity);

        long Count();

        void Commit();

    }

    /// <summary>
    ///     This interface flags all the Model classes.
    ///     Its there to restrict the types that an IRepository can take on.
    /// </summary>
    public interface IModel
    {
        Guid Id { get; set; }
    }
}