using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EDU.Business.Abstract
{
    public interface IGenericService<T> where T : class
    {
        Task<List<T>> TGetAllAsync();
        Task<T> TGetByIdAsync(int id);
        Task TAddAsync(T entity);
        Task TUpdateAsync(T entity);
        Task TDeleteAsync(int id);
        Task<int> TCountAsync();
        Task<T> TGetByFilterAsync(Expression<Func<T, bool>> predicate);
        Task<int> TFilterCountAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> TGetFilterListAsync(Expression<Func<T, bool>> predicate);
    }
}
