using FinancialManager.Application.DTOs;
using FinancialManager.Application.Services.Service;
using FinancialManager.Domain.FiltersDb;

namespace FinancialManager.Application.Services.Interface
{
    public interface IBankService
    {
        Task<ResultService<BankDto>> CreateAsync(BankDto bankDto);
        Task<ResultService<ICollection<BankDto>>> GetAsync();
        Task<ResultService<BankDto>> GetByIdAsync(int id);
        Task<ResultService> UpdateAsync(BankDto bankDto);
        Task<ResultService> DeleteAsync(int id);
        Task<ResultService<PagedBaseReponseDto<BankDto>>> GetPagedAsync(BankFilterDb bankFilterDb);
    }
}
