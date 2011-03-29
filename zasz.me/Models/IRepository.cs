using System.Collections.Generic;

namespace zasz.me.Models
{
    public interface IRepository<Model>
    {
        void Save(Model Instance);

        Model Get(string ID);

        void Delete(Model Entity);

        List<Model> All();

        long Count();
    }
}