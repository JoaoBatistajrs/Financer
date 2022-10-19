using FinancialManager.Application.DTOs;
using FinancialManager.Application.Services.Service;

namespace FinancialManager.Application.Services.Interface
{
    public interface ICategoryService
    {
        Task<ResultService<CategoryDto>> CreateAsync(CategoryDto categoryDto);
    }
}
