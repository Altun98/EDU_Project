using EDU.DataAccess.Abstract;
using EDU.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EDU.DataAccess.Repositories
{
    public class GenericRepository<T>(EDUDbContext _context) : IRepository<T> where T : class
    {
        public DbSet<T> Table { get => _context.Set<T>(); }
        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<int> CountAsync()
        {
            return await Table.CountAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await Table.FindAsync(id);
            Table.Remove(value);
            await _context.SaveChangesAsync();
        }

        public async Task<int> FilterCountAsync(Expression<Func<T, bool>> predicate)
        {
            var value = await Table.Where(predicate).CountAsync();
            return value;
        }

        public async Task<List<T>> GetAllAsync()
        {
            var result = await Table.ToListAsync();
            return result;
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> predicate)
        {
            var value = await Table.Where(predicate).FirstOrDefaultAsync();
            return value;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var value = await Table.FindAsync(id);
            return value;
        }

        public async Task<List<T>> GetFilterListAsync(Expression<Func<T, bool>> predicate)
        {
            var value = await Table.Where(predicate).ToListAsync();
            return value;
        }

        public async Task UpdateAsync(T entity)
        {
            Table.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
