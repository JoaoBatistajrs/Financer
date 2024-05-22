using FinancialManager.Application.ApiModels;
using FinancialManager.Application.Services.Service;

namespace FinancialManager.Services.Interface
{
    public interface IRegisterService
    {
        Task<ResultService<RegisterModel>> CreateAsync(RegisterModel registerModel);
        Task<ResultService<ICollection<RegisterDetailModel>>> GetAsync();
        Task<ResultService<RegisterDetailModel>> GetByIdAsync(int id);
        Task<ResultService> UpdateAsync(int id, RegisterModel registerModel);
        Task<ResultService> DeleteAsync(int id);
    }
}
