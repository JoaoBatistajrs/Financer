using FinancialManager.Domain.Models;

namespace FinancialManager.Domain.Repositories.Interface
{
    public interface IRegisterRepository
    {
        Task<ICollection<Register>> GetRegisterAsync();
        Task<Register> GetByIdAsync(int id);
        Task<Register> CreateAsync(Register register);
        Task UpdateAsync(Register register);
        Task DeleteAsync(Register register);
    }
}
