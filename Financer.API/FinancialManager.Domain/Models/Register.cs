using FinancialManager.Domain.Interfaces;

namespace FinancialManager.Domain.Models
{
    public class Register : IEntityBase, IRegister
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int BankId { get; set; }
        public Bank Bank { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public decimal Amount { get; set; }
        public int RegisterTypeId { get; set; }
        public RegisterType RegisterType { get; set; }

        public Register(string description, DateTime date, int bankId, int categoryId, decimal amount, int registerTypeId)
        {
            Description = description;
            Date = date;
            BankId = bankId;
            CategoryId = categoryId;
            Amount = amount;
            RegisterTypeId = registerTypeId;
        }

        public Register(int id, string description, DateTime date, int bankId, int categoryId, decimal amount, int registerTypeId)
        {
            Id = id;
            Description = description;
            Date = date;
            BankId = bankId;
            CategoryId = categoryId;
            Amount = amount;
            RegisterTypeId = registerTypeId;
        }

        public void Edit(string description, DateTime date, int bankId, int categoryId, decimal amount, int registerTypeId)
        {
            Description = description;
            Date = date;
            BankId = bankId;
            CategoryId = categoryId;
            Amount = amount;
            RegisterTypeId = registerTypeId;
        }
    }
}
