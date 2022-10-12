using FinancialManager.Domain.Enum;

namespace FinancialManager.Domain.Interfaces
{
    public interface IAddCategoryRequest
    {
        public string Name { get; set; }
        public TypeEnum Type { get; set; }
    }
}
