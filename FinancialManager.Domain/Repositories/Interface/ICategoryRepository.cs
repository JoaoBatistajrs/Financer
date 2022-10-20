using FinancialManager.Domain.Models;

namespace FinancialManager.Domain.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<ICollection<Category>> GetCategoryAsync();
        Task<Category> GetByIdAsync(int id);
        Task<Category> CreateAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(Category category);
        Task<int> GetIdByName(string name);
    }
}
