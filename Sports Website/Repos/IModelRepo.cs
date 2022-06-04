using System.Linq;

namespace Repos
{
    public interface IModelRepo<T>
    {
        void Create(T entity);
        IQueryable<T> Read();
        void Update(T entity);
        void Delete(int uid);
        T GetByID(int id);
    }
}
