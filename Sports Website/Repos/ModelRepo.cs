using Data_Context;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Linq;

namespace Repos
{
    public class ModelRepo<T> : IModelRepo<T> where T : BaseClass
    {
        DbContext context;
        DbSet<T> table;
        public ModelRepo(Context _context)
        {
            context = _context;
            table = context.Set<T>();
        }

        public void Create(T entity)
        {
            table.Add(entity);
        }

        public void Delete(int uid)
        {
            var user = GetByID(uid);
            table.Remove(user);
        }

        public T GetByID(int id)
        {
            return table.FirstOrDefault(e => e.ID == id);
        }

        public IQueryable<T> Read()
        {
            return table;
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
