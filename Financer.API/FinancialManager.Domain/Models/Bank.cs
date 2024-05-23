using FinancialManager.Domain.Interfaces;

namespace FinancialManager.Domain.Models
{
    public class Bank : IEntityBase, IBank
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Agency { get; set; }
        public string? AccountNumber { get; set; }
        public ICollection<Register> Registers { get; set; }    

        public Bank(string? name, string? agency, string? accountNumber)
        {
            Name = name;
            Agency = agency;
            AccountNumber = accountNumber;
        }
    }
}
