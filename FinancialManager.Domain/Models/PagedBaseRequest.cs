using FinancialManager.Domain.Interfaces;

namespace FinancialManager.Domain.Models
{
    public class PagedBaseRequest : IPagedBaseRequest
    {
        public PagedBaseRequest()
        {
            PageIndex = 1;
            PageSize = 10;
            OrderByProperty = "Id";
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }   
        public string OrderByProperty { get; set; }
    }
}
