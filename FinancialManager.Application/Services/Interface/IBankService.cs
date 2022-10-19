using FinancialManager.Application.DTOs;
using FinancialManager.Application.Services.Service;

namespace FinancialManager.Application.Services.Interface
{
    public interface IBankService
    {
        Task<ResultService<CategoryDto>> CreateAsync(CategoryDto bankDto);
    }
}
