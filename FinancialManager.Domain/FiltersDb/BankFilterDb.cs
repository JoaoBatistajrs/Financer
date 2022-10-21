using FinancialManager.Domain.Models;

namespace FinancialManager.Domain.FiltersDb
{
    public class BankFilterDb : PagedBaseRequest
    {
        public string? Name { get; set; }
    }
}
