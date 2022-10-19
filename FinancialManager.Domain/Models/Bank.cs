using FinancialManager.Domain.Enum;
using FinancialManager.Domain.Interfaces;

namespace FinancialManager.Domain.Models
{
    public class Bank : IEntityBase, IBank
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Agency { get; set; }
        public string? AccountNumber { get; set; }
        public AccountTypeEnum AccountType { get; set; }
        public ICollection<Register> Registers { get; set; }    

        public Bank(string? name, string? agency, string? accountNumber, AccountTypeEnum accountType)
        {
            Name = name;
            Agency = agency;
            AccountNumber = accountNumber;
            AccountType = accountType;
            Registers = new List<Register>();
        }

        public Bank(int id, string? name, string? agency, string? accountNumber, AccountTypeEnum accountType)
        {
            Id = id;
            Name = name;
            Agency = agency;
            AccountNumber = accountNumber;
            AccountType = accountType;
        }
    }
}
