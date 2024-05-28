using FinancialManager.Application.ApiModels;
using FinancialManager.Application.Services.Service;

namespace FinancialManager.Services.Interface
{
    public interface IRegisterService
    {
        Task<RegisterModelCreate> CreateAsync(RegisterModelCreate registerModel);
        Task<ICollection<RegisterDetailModel>> GetAsync();
        Task<RegisterDetailModel> GetByIdAsync(int id);
        Task UpdateAsync(int id, RegisterModelCreate registerModel);
        Task<bool> DeleteAsync(int id);
    }
}
