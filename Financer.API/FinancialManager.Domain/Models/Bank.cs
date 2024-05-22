using FinancialManager.Domain.Interfaces;

namespace FinancialManager.Domain.Models
{
    public class Bank : IEntityBase, IBank
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Agency { get; set; }
        public string? AccountNumber { get; set; }
        public int AccountTypeId {  get; set; }
        public AccountType AccountType { get; set; }
        public ICollection<Register> Registers { get; set; }    

        public Bank(string? name, string? agency, string? accountNumber, int accountTypeId)
        {
            Name = name;
            Agency = agency;
            AccountNumber = accountNumber;
            AccountTypeId = accountTypeId;
            Registers = new List<Register>();
        }

        public Bank(int id, string? name, string? agency, string? accountNumber, int accountTypeId)
        {
            Id = id;
            Name = name;
            Agency = agency;
            AccountNumber = accountNumber;
            AccountTypeId = accountTypeId;
        }
    }
}
