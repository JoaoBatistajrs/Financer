
namespace FinancialManager.Application.ApiModels
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ExpenseTypeId { get; set; }
        public string ExpenseTypeName { get; set; }
    }

    public class CategoryModelCreate
    {
        public string Name { get; set; }
        public int ExpenseTypeId { get; set; }
    }
}
