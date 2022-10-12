using FinancialManager.Domain.Enum;
using FinancialManager.Domain.Interfaces;

namespace FinancialManager.Domain.Models
{
    public class AddCategoryRequest : IAddCategoryRequest
    {
        public string Name { get; set; }
        public TypeEnum Type { get; set; }
    }
}
