using FinancialManager.Application.DTOs;
using FinancialManager.Application.Services.Service;

namespace FinancialManager.Application.Services.Interface
{
    public interface ICategoryService
    {
        Task<ResultService<CategoryDto>> CreateAsync(CategoryDto categoryDto);
        Task<ResultService<ICollection<CategoryDto>>> GetAsync();
        Task<ResultService<CategoryDto>> GetByIdAsync(int id);
        Task<ResultService> UpdateAsync(CategoryDto categoryDto);
        Task<ResultService> DeleteAsync(int id);
    }
}
