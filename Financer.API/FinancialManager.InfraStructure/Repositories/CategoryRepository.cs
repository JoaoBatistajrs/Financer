using FinancialManager.Domain.Models;
using FinancialManager.Domain.Repositories.Interface;
using FinancialManager.InfraStructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace FinancialManager.InfraStructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FinancialManagerDbContext _context;

        public CategoryRepository(FinancialManagerDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection> GetAsync()
        {
            return await _context.Set<Category>()
                .Include(x => x.Type)
                .ToListAsync();        }
    }
}
