using FinancialManager.Domain.Interfaces;

namespace FinancialManager.Domain.Models
{
    public class AccountType : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }    
    }
}
