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
            return await _context.Registers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Register>> GetRegisterAsync()
        {
            return await _context.Registers.ToListAsync();
        }

        public async Task UpdateAsync(Register register)
        {
            _context.Update(register);
            await _context.SaveChangesAsync();
        }
    }
}
