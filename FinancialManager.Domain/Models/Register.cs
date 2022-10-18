using FinancialManager.Domain.Enum;
using FinancialManager.Domain.Interfaces;

namespace FinancialManager.Domain.Models
{
    public class Register : IEntityBase, IRegister
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string BankId { get; set; }
        public string CategoryId { get; set; }
        public decimal Amount { get; set; }
        public RegisterTypeEnum RegisterType { get; set; }
        public virtual Bank Bank { get; set; }
        public virtual Category Category { get; set; }

        public Register(string description, DateTime date, string bankId, string categoryId, decimal amount, RegisterTypeEnum registerType)
        {
            Description = description;
            Date = date;
            BankId = bankId;
            CategoryId = categoryId;
            Amount = amount;
            RegisterType = registerType;
        }

        public Register(int id, string description, DateTime date, string bankId, string categoryId, decimal amount, RegisterTypeEnum registerType)
        {
            Id = id;
            Description = description;
            Date = date;
            BankId = bankId;
            CategoryId = categoryId;
            Amount = amount;
            RegisterType = registerType;
        }

        public Register()
        {

        }
    }
}
