using FinancialManager.Domain.Models;

namespace FinancialManager.Domain.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAndPasswordAsync(string email, string password);
    }
}
