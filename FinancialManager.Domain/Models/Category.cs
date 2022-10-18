using FinancialManager.Domain.Enum;
using FinancialManager.Domain.Interfaces;

namespace FinancialManager.Domain.Models
{
    public class Category : IEntityBase, ICategoryRepository
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ExpenseTypeEnum Type { get; set; }
        public ICollection<Register> Registers { get; set; }

        public Category(string name, ExpenseTypeEnum type)
        {
            Name = name;
            Type = type;
        }

        public Category(int id, string name, ExpenseTypeEnum type)
        {
            Id = id;
            Name = name;
            Type = type;
        }
    }
}
