using FinancialManager.Domain.Enum;

namespace FinancialManager.Domain.Interfaces
{
    public interface ICategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TypeEnum Type { get; set; }
    }
}
