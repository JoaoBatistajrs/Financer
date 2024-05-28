using FinancialManager.Domain.Models;
using FinancialManager.Domain.Repositories.Interface;
using FinancialManager.InfraStructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace FinancialManager.InfraStructure.Repositories
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly FinancialManagerDbContext _context;

        public RegisterRepository(FinancialManagerDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection> GetAsync()
        {
            return await _context.Set<Register>()
                .Include(b => b.Bank)
                .Include(c => c.Category) 
                .Include(r => r.RegisterType)
                .ToListAsync();
        }
    }
}
