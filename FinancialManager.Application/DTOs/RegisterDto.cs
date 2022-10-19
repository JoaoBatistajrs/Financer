using FinancialManager.Domain.Enum;
using FinancialManager.Domain.Models;

namespace FinancialManager.Application.DTOs
{
    public class RegisterDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int BankId { get; set; }
        public int CategoryId { get; set; }
        public decimal Amount { get; set; }
        public RegisterTypeEnum RegisterType { get; set; }
    }
}
