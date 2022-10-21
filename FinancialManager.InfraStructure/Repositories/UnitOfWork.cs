using FinancialManager.Domain.Repositories.Interface;
using FinancialManager.InfraStructure.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace FinancialManager.InfraStructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FinancialManagerDbContext _context;
        private IDbContextTransaction _transaction;
        public UnitOfWork(FinancialManagerDbContext context)
        {
            _context = context;
        }

        public async Task BeginTransaction()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            await _transaction.CommitAsync();
        }

        public async Task RollBack()
        {
            await _transaction.RollbackAsync();
        }

        public void Dispose()
        {
            _transaction.Dispose();
        }
    }
}
