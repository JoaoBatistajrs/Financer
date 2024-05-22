using FinancialManager.Domain.Enum;

namespace FinancialManager.Application.ApiModels
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ExpenseTypeEnum Type { get; set; }
    }
}
