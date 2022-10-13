using FinancialManager.Domain.Enum;
using FinancialManager.Domain.Interfaces;

namespace FinancialManager.Domain.Models
{
    public class Register : IEntityBase, IRegister
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Bank Bank { get; set; }
        public Category Category { get; set; }
        public decimal Amount { get; set; }
        public RegisterTypeEnum RegisterType { get; set; }
    }
}
