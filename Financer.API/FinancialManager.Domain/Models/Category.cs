using FinancialManager.Domain.Interfaces;

namespace FinancialManager.Domain.Models
{
    public class Category : IEntityBase, ICategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ExpenseTypeId {  get; set; }
        public ExpenseType Type { get; set; }
        public ICollection<Register> Registers { get; set; }

        public Category(string name, int expenseTypeId)
        {
            Name = name;
            ExpenseTypeId = expenseTypeId;
            Registers = new List<Register>();
        }

        public Category(int id, string name, int expenseTypeId)
        {
            Id = id;
            Name = name;
            ExpenseTypeId = expenseTypeId;
        }
    }
}
