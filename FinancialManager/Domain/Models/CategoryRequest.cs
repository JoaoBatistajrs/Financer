using FinancialManager.Domain.Enum;
using FinancialManager.Domain.Interfaces;

namespace FinancialManager.Domain.Models
{
    public class CategoryRequest : ICategory
    {
        public string Name { get; set; }
        public ExpenseTypeEnum Type { get; set; }
    }
}
