using FinancialManager.Application.DTOs;

namespace FinancialManager.Application.Services.Interface
{
    public interface IBankService
    {
        Task<BankDto> CreateAsync(BankDto bankDto);
        Task<ICollection<BankDto>> GetAsync();
        Task<BankDto> GetByIdAsync(int id);
        Task UpdateAsync(int id, BankDto bankDto);
        Task<bool> DeleteAsync(int id);
    }
}
