using FinancialManager.Domain.Enum;

namespace FinancialManager.Application.ApiModels
{
    public class RegisterModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int BankId { get; set; }
        public string BankName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public decimal Amount { get; set; }
        public RegisterTypeEnum RegisterType { get; set; }
    }
}
