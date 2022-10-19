using FinancialManager.Application.DTOs;
using FinancialManager.Application.Services.Service;
using FinancialManager.Domain.Models;

namespace FinancialManager.Services.Interface
{
    public interface IRegisterService
    {
        Task<ResultService<RegisterDto>> CreateAsync(RegisterDto registerDto);
    }
}
