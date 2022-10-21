namespace FinancialManager.Domain.Interfaces
{
    public interface IPagedBaseRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string OrderByProperty { get; set; }
    }
}
