using System.Collections;

namespace FinancialManager.Domain.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<ICollection> GetAsync();
    }
}
