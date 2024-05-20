using System.Linq.Expressions;

namespace FinancialManager.Domain.Repositories.Interface
{
    public interface IEntitiesRepository<T> where T : class
    {
        Task<ICollection<T>> GetAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(int id, T entity);
        Task<bool> DeleteAsync(int id);
        Task<ICollection<T>> GetAsync(Expression<Func<T, bool>> filter);
    }
}