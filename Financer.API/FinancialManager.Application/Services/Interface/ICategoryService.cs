using FinancialManager.Application.ApiModels;
using FinancialManager.Application.Services.Service;

namespace FinancialManager.Application.Services.Interface
{
    public interface ICategoryService
    {
        Task<ResultService<CategoryModel>> CreateAsync(CategoryModel categoryModel);
        Task<ResultService<ICollection<CategoryModel>>> GetAsync();
        Task<ResultService<CategoryModel>> GetByIdAsync(int id);
        Task<ResultService> UpdateAsync(int id, CategoryModel categoryModel);
        Task<ResultService> DeleteAsync(int id);
    }
}
