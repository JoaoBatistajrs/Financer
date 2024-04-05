using FinancialManager.Application.DTOs;
using FinancialManager.Application.Services.Service;

namespace FinancialManager.Application.Services.Interface
{
    public interface IBankService
    {
        Task<ResultService<BankDto>> CreateAsync(BankDto bankDto);
        Task<ResultService<ICollection<BankDto>>> GetAsync();
        Task<ResultService<BankDto>> GetByIdAsync(int id);
        Task<ResultService> UpdateAsync(int id, BankDto bankDto);
        Task<ResultService> DeleteAsync(int id);
    }
}
