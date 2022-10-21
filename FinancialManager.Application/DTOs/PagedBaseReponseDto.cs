namespace FinancialManager.Application.DTOs
{
    public class PagedBaseReponseDto<T>
    {
        public PagedBaseReponseDto(int totalRegisters, List<T> data)
        {
            TotalRegisters = totalRegisters;
            Data = data;
        }

        public int TotalRegisters { get; private set; }
        public List<T> Data { get; private set; }
    }
}
