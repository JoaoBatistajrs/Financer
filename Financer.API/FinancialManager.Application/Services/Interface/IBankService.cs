using FinancialManager.Application.DTOs;

namespace FinancialManager.Application.Services.Interface
{
    public interface IBankService
    {
        Task<BankModel> CreateAsync(BankModel bankDto);
        Task<ICollection<BankModel>> GetAsync();
        Task<BankModel> GetByIdAsync(int id);
        Task UpdateAsync(int id, BankModel bankDto);
        Task<bool> DeleteAsync(int id);
    }
}
