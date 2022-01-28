using Microsoft.EntityFrameworkCore;
using ProcessMaker_Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProcessMaker_Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ProcessMakerDbContext context;
        internal DbSet<T> dbSet;

        public GenericRepository(ProcessMakerDbContext context)
        {
            this.context = context;

            dbSet = context.Set<T>();
        }

        public virtual async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public bool Delete(int id)
        {
            var model = dbSet.Find(id);

            if (model == null)
            {
                return false;
            }

            dbSet.Remove(model);
            return true;
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            var model = await dbSet.FindAsync(id);
            return model;
        }

        public bool Update(T entity)
        {
            if (entity != null)
            {
                dbSet.Update(entity);
                return true;
            }
            return false;
        }

        public virtual async Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToListAsync();
        }
    }
}
