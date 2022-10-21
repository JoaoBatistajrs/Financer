using FinancialManager.Domain.Models;

namespace FinancialManager.Domain.Authentication
{
    public interface ITokenGenerator
    {
        dynamic Generator(User user);
    }
}
