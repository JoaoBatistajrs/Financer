using FinancialManager.Domain.Models;

namespace FinancialManager.Domain.Repositories.Interface
{
    public interface IBankRepository
    {
        Task<ICollection<Bank>> GetBankAsync();
        Task<Bank> GetByIdAsync(int id);
        Task<Bank> CreateAsync(Bank bank);
        Task UpdateAsync(Bank bank);
        Task DeleteAsync(Bank bank);
        Task<int> GetIdByName(string name); 
    }
}
