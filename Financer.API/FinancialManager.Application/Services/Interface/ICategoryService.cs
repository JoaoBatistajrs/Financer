using FinancialManager.Application.ApiModels;

namespace FinancialManager.Application.Services.Interface
{
    public interface ICategoryService
    {
        Task<CategoryModel> CreateAsync(CategoryModel categoryModel);
        Task<ICollection<CategoryModel>> GetAsync();
        Task<CategoryModel> GetByIdAsync(int id);
        Task UpdateAsync(int id, CategoryModel categoryModel);
        Task<bool> DeleteAsync(int id);
    }
}
