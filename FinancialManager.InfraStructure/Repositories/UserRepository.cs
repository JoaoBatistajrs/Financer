using FinancialManager.Domain.Models;
using FinancialManager.Domain.Repositories.Interface;
using FinancialManager.InfraStructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace FinancialManager.InfraStructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FinancialManagerDbContext _context;

        public UserRepository(FinancialManagerDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email && x.PassWord == password);
        }
    }
}
