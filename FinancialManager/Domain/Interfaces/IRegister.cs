using FinancialManager.Domain.Enum;
using FinancialManager.Domain.Models;
using System.Security;

namespace FinancialManager.Domain.Interfaces
{
    public interface IRegister
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }  
        public Bank Bank { get; set; }
        public Category Category { get; set; }  
        public decimal Amount { get; set; }
        public RegisterTypeEnum RegisterType { get; set; }
    }
}
