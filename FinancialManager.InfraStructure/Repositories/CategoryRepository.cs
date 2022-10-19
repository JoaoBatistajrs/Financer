using FinancialManager.Domain.Models;
using FinancialManager.Domain.Repositories.Interface;
using FinancialManager.InfraStructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FinancialManager.InfraStructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FinancialManagerDbContext _context;
        public CategoryRepository(FinancialManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task DeleteAsync(Category category)
        {
            _context.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Category>> GetCategoryAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}
