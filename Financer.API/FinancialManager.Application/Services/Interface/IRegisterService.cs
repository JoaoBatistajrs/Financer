using FinancialManager.Application.DTOs;
using FinancialManager.Application.Services.Service;

namespace FinancialManager.Services.Interface
{
    public interface IRegisterService
    {
        Task<ResultService<RegisterModel>> CreateAsync(RegisterModel registerDto);
        Task<ResultService<ICollection<RegisterDetailModel>>> GetAsync();
        Task<ResultService<RegisterDetailModel>> GetByIdAsync(int id);
        Task<ResultService> UpdateAsync(int id, RegisterModel registerDto);
        Task<ResultService> DeleteAsync(int id);
    }
}
