using FinancialManager.Domain.Interfaces;

namespace FinancialManager.Domain.Models
{
    public class ExpenseType : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
