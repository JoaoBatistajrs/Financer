using FinancialManager.Domain.Enum;
using FinancialManager.Domain.Interfaces;

namespace FinancialManager.Domain.Models
{
    public class Category : ICategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TypeEnum Type { get; set; }  
    }
}
