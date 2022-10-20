using FinancialManager.Application.DTOs;
using FinancialManager.Application.Services.Service;

namespace FinancialManager.Services.Interface
{
    public interface IRegisterService
    {
        Task<ResultService<RegisterDto>> CreateAsync(RegisterDto registerDto);
        Task<ResultService<ICollection<RegisterDetailDto>>> GetAsync();
        Task<ResultService<RegisterDetailDto>> GetByIdAsync(int id);
        Task<ResultService> UpdateAsync(RegisterDto registerDto);
        Task<ResultService> DeleteAsync(int id);
    }
}
