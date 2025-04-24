using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EDU.DataAccess.Abstract
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<int> CountAsync();
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> predicate);
        Task<int> FilterCountAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetFilterListAsync(Expression<Func<T, bool>> predicate);
    }
}
