using FinancialManager.Domain.Models;

namespace FinancialManager.Domain.Interfaces
{
    public interface IRegister
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }  
        public Bank Bank { get; set; }
        public Category Category { get; set; }  
        public decimal Amount { get; set; }
        public int RegisterTypeId { get; set; }
        public RegisterType RegisterType { get; set; }
    }
}
