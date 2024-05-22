using FinancialManager.Application.ApiModels;
using FinancialManager.Application.Services.Service;

namespace FinancialManager.Services.Interface
{
    public interface IRegisterService
    {
        Task<RegisterModel> CreateAsync(RegisterModel registerModel);
        Task<ICollection<RegisterModel>> GetAsync();
        Task<RegisterModel> GetByIdAsync(int id);
        Task UpdateAsync(int id, RegisterModel registerModel);
        Task<bool> DeleteAsync(int id);
    }
}
