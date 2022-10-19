using FinancialManager.Domain.Enum;
using FinancialManager.Domain.Models;

namespace FinancialManager.Application.DTOs
{
    public class BankDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Agency { get; set; }
        public string? AccountNumber { get; set; }
        public AccountTypeEnum AccountType { get; set; }
        public ICollection<Register> Registers { get; set; }
    }
}
