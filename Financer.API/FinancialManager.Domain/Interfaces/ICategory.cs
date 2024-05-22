using FinancialManager.Domain.Models;

namespace FinancialManager.Domain.Interfaces
{
    public interface ICategory
    {
        public string Name { get; set; }
        public ExpenseType Type { get; set; }
    }
}
