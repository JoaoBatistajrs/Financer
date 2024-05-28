
namespace FinancialManager.Application.ApiModels
{
    public class RegisterDetailModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string BankName { get; set; }
        public string CategoryName { get; set; }
        public string RegisterTypeName { get; set; }
    }
}
