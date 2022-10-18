using FinancialManager.Domain.Models;
using FinancialManager.Domain.Repositories.Interface;
using FinancialManager.InfraStructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FinancialManager.InfraStructure.Repositories
{
    public class BankRepository : IBankRepository
    {
        private readonly FinancialManagerDbContext _context;
        public BankRepository(FinancialManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Bank> CreateAsync(Bank bank)
        {
            _context.Add(bank);
            await _context.SaveChangesAsync();

            return bank;
        }

        public async Task DeleteAsync(Bank bank)
        {
            _context.Remove(bank);
            await _context.SaveChangesAsync();
        }

        public async Task<Bank> GetByIdAsync(int id)
        {
            return await _context.Banks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Bank>> GetRegisterAsync()
        {
            return await _context.Banks.ToListAsync();
        }

        public async Task UpdateAsync(Bank bank)
        {
            _context.Update(bank);
            await _context.SaveChangesAsync();
        }
    }
}
