
namespace FinancialManager.Application.ApiModels
{
    public class RegisterModelCreate
    {
        public int Id { get; set; } 
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int BankId { get; set; }
        public int CategoryId { get; set; }
        public decimal Amount { get; set; }
        public int RegisterTypeId { get; set; }
    }
}
