using System.Linq;

namespace zasz.me.Models
{
    public interface IRepository<Model>
    {
        void Save(Model Instance);

        Model Get(string ID);

        void Delete(int ID);

        IQueryable<Model> All();

        long Count();
    }
}