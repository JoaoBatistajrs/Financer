using FinancialManager.Domain.Enum;

namespace FinancialManager.Application.DTOs
{
    public class RegisterDetailDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string BankName { get; set; }
        public string CategoryName { get; set; }
        public decimal Amount { get; set; }
        public RegisterTypeEnum RegisterType { get; set; }
    }
}
