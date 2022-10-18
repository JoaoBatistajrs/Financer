using FinancialManager.Domain.Enum;

namespace FinancialManager.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        public string Name { get; set; }
        public ExpenseTypeEnum Type { get; set; }
    }
}
