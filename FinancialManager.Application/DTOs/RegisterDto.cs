using FinancialManager.Domain.Enum;
using FinancialManager.Domain.Models;

namespace FinancialManager.Application.DTOs
{
    public class RegisterDto
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
    }
}
