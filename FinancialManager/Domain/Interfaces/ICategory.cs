using FinancialManager.Domain.Enum;

namespace FinancialManager.Domain.Interfaces
{
    public interface ICategory
    {
        public string Name { get; set; }
        public ExpenseTypeEnum Type { get; set; }
    }
}
