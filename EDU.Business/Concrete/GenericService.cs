using EDU.Business.Abstract;
using EDU.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EDU.Business.Concrete
{
    public class GenericService<T>(IRepository<T> _repository) : IGenericService<T> where T : class
    {
        public async Task TAddAsync(T entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task<int> TCountAsync()
        {
            return await _repository.CountAsync();
        }

        public async Task TDeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<int> TFilterCountAsync(Expression<Func<T, bool>> predicate)
        {
            return await _repository.FilterCountAsync(predicate);
        }

        public async Task<List<T>> TGetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> TGetByFilterAsync(Expression<Func<T, bool>> predicate)
        {
            return await _repository.GetByFilterAsync(predicate);
        }

        public async Task<T> TGetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<T>> TGetFilterListAsync(Expression<Func<T, bool>> predicate)
        {
            return await _repository.GetFilterListAsync(predicate);
        }

        public async Task TUpdateAsync(T entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}
