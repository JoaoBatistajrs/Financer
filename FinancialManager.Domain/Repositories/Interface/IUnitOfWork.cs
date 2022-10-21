namespace FinancialManager.Domain.Repositories.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        Task BeginTransaction();
        Task Commit();
        Task RollBack();
    }
}
