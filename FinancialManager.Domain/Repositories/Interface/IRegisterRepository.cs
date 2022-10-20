using FinancialManager.Domain.Models;

namespace FinancialManager.Domain.Repositories.Interface
{
    public interface IRegisterRepository
    {
        Task<ICollection<Register>> GetRegistersAsync();
        Task<Register> GetByIdAsync(int id);
        Task<Register> CreateAsync(Register register);
        Task UpdateAsync(Register register);
        Task DeleteAsync(Register register);
        Task<ICollection<Register>> GetByBankIdAsync(int bankId);
        Task<ICollection<Register>> GetByCategoryIdAsync(int categoryId);
    }
}
