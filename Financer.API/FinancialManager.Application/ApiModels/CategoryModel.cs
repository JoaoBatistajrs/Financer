using FinancialManager.Domain.Models;

namespace FinancialManager.Application.ApiModels
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ExpenseTypeId { get; set; }
        public ExpenseType Type { get; set; }
    }
}
