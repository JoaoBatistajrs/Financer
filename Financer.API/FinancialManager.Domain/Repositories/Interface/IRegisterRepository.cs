using System.Collections;

namespace FinancialManager.Domain.Repositories.Interface
{
    public interface IRegisterRepository
    {
        Task<ICollection> GetAsync();
    }
}
