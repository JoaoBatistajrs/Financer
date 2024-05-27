using FinancialManager.Domain.Models;

namespace FinancialManager.Application.ApiModels
{
    public class BankModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Agency { get; set; }
        public string? AccountNumber { get; set; }
        public decimal AccountBalance { get; set; }
    }
}
