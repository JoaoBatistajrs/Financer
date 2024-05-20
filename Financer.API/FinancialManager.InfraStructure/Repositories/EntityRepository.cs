using FinancialManager.Domain.Repositories.Interface;
using FinancialManager.InfraStructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinancialManager.InfraStructure.Repositories
{
    public class EntitiesRepository<T> : IEntitiesRepository<T> where T : class
    {
        private readonly FinancialManagerDbContext _context;

        public EntitiesRepository(FinancialManagerDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<T>> GetAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> CreateAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(int id, T entity)
        {
            var existingEntity = await _context.FindAsync<T>(id);

            if (existingEntity == null)
            {
                throw new Exception("Entity not found");
            }

            foreach (var property in typeof(T).GetProperties())
            {
                var updatedValue = property.GetValue(entity);
                if (updatedValue != null)
                {
                    property.SetValue(existingEntity, updatedValue);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<T>> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().Where(filter).ToListAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _context.Set<T>().FindAsync(id);

            if (result == null)
                return false;

            _context.Remove(result);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}