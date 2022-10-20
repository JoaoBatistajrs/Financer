using FinancialManager.Domain.Models;
using FinancialManager.Domain.Repositories.Interface;
using FinancialManager.InfraStructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FinancialManager.InfraStructure.Repositories
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly FinancialManagerDbContext _context;
        public RegisterRepository(FinancialManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Register> CreateAsync(Register register)
        {
            _context.Add(register);
            await _context.SaveChangesAsync();  

            return register;
        }

        public async Task DeleteAsync(Register register)
        {
            _context.Remove(register);
            await _context.SaveChangesAsync();
        }

        public async Task<Register> GetByIdAsync(int id)
        {
            var register = await _context.Registers
                            .Include(x => x.Bank)
                            .Include(x => x.Category)
                            .FirstOrDefaultAsync(x => x.Id == id);

            return register;
        }

        public async Task<ICollection<Register>> GetByBankIdAsync(int bankId)
        {
            return await _context.Registers
                            .Include(x => x.Bank)
                            .Include(x => x.Category)
                            .Where(x => x.BankId == bankId).ToListAsync();

        }

        public async Task<ICollection<Register>> GetByCategoryIdAsync(int categoryId)
        {
            return await _context.Registers
                            .Include(x => x.Bank)
                            .Include(x => x.Category)
                            .Where(x => x.CategoryId == categoryId).ToListAsync();


        }

        public async Task<ICollection<Register>> GetRegistersAsync()
        {
            return await _context.Registers
                            .Include(x => x.Bank)
                            .Include(x => x.Category)
                            .ToListAsync();
        }
    
        public async Task UpdateAsync(Register register)
        {
            _context.Update(register);
            await _context.SaveChangesAsync();
        }
    }
}
