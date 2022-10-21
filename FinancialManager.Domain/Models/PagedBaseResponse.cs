using FinancialManager.Domain.Interfaces;

namespace FinancialManager.Domain.Models
{
    public class PagedBaseResponse<T> : IPagedBaseResponse<T>
    {
        public List<T> Data { get; set; }
        public int TotalPages { get; set; }
        public int TotalRegisters { get; set; }
    }
}
