using FinancialManager.Application.ApiModels;

namespace FinancialManager.Application.Services.Interface
{
    public interface IRegisterTypeService
    {
        Task<RegisterTypeModel> CreateAsync(RegisterTypeModel registerType);
        Task<ICollection<RegisterTypeModel>> GetAsync();
        Task<RegisterTypeModel> GetByIdAsync(int id);
        Task UpdateAsync(int id, RegisterTypeModel registerType);
        Task<bool> DeleteAsync(int id);
    }
}
