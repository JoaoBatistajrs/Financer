using FinancialManager.Application.ApiModels;

namespace FinancialManager.Application.Services.Interface
{
    public interface IAccountTypeService
    {
        Task<AccountTypeModel> CreateAsync(AccountTypeModel accountType);
        Task<ICollection<AccountTypeModel>> GetAsync();
        Task<AccountTypeModel> GetByIdAsync(int id);
        Task UpdateAsync(int id, AccountTypeModel accountType);
        Task<bool> DeleteAsync(int id);
    }
}
