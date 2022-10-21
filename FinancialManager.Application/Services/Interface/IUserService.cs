using FinancialManager.Application.DTOs;
using FinancialManager.Application.Services.Service;

namespace FinancialManager.Application.Services.Interface
{
    public interface IUserService
    {
        Task<ResultService<dynamic>> GenerateTokenAsync(UserDto userDto);
    }
}
