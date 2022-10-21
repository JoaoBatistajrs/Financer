using FinancialManager.Domain.FiltersDb;
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

        public async Task<ICollection<Bank>> GetBankAsync()
        {
            return await _context.Banks.ToListAsync();
        }

        public async Task UpdateAsync(Bank bank)
        {
            _context.Update(bank);
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetIdByName(string name)
        {
            return (await _context.Banks.FirstOrDefaultAsync(x => x.Name == name))?.Id ?? 0;
        }

        public async Task<PagedBaseResponse<Bank>> GetPagedAsync(BankFilterDb request)
        {
            var bank = _context.Banks.AsQueryable();
            if(!string.IsNullOrEmpty(request.Name))
                bank = bank.Where(x => x.Name.Contains(request.Name));

            return await PagedBaseResponseHelper.GetResponseAsync<PagedBaseResponse<Bank>, Bank>(bank, request);
        }
    }
}
