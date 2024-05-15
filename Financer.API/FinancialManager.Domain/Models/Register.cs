using FinancialManager.Domain.Enum;
using FinancialManager.Domain.Interfaces;

namespace FinancialManager.Domain.Models
{
    public class Register : IEntityBase, IRegister
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int BankId { get; set; }
        public int CategoryId { get; set; }
        public decimal Amount { get; set; }
        public RegisterTypeEnum RegisterType { get; set; }
        public  Bank Bank { get; set; }
        public  Category Category { get; set; }

        public Register(string description, DateTime date, int bankId, int categoryId, decimal amount, RegisterTypeEnum registerType)
        {
            Description = description;
            Date = date;
            BankId = bankId;
            CategoryId = categoryId;
            Amount = amount;
            RegisterType = registerType;
        }

        public Register(int id, string description, DateTime date, int bankId, int categoryId, decimal amount, RegisterTypeEnum registerType)
        {
            Id = id;
            Description = description;
            Date = date;
            BankId = bankId;
            CategoryId = categoryId;
            Amount = amount;
            RegisterType = registerType;
        }

        public void Edit(int id, string description, DateTime date, int bankId, int categoryId, decimal amount, RegisterTypeEnum registerType)
        {
            Id = id;
            Description = description;
            Date = date;
            BankId = bankId;
            CategoryId = categoryId;
            Amount = amount;
            RegisterType = registerType;
        }
    }
}
