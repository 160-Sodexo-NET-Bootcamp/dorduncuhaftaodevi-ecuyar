using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProcessMaker_Data.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<bool> Add(T entity);
        bool Update(T entity);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        bool Delete(int id);
        Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate);
    }
}
