using FinancialManager.Domain.Enum;
using FinancialManager.Domain.Interfaces;

namespace FinancialManager.Domain.Models
{
    public class Bank : IEntityBase, IBank
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Agency { get; set; }
        public string? AccountNumber { get; set; }
        public AccountTypeEnum AccountType { get; set; }
    }
}
