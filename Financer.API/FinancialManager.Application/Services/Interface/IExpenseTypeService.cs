using FinancialManager.Application.ApiModels;

namespace FinancialManager.Application.Services.Interface
{
    public interface IExpenseTypeService
    {
        Task<ExpenseTypeModel> CreateAsync(ExpenseTypeModel expenseType);
        Task<ICollection<ExpenseTypeModel>> GetAsync();
        Task<ExpenseTypeModel> GetByIdAsync(int id);
        Task UpdateAsync(int id, ExpenseTypeModel expenseType);
        Task<bool> DeleteAsync(int id);
    }
}
