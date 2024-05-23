namespace FinancialManager.Application.ApiModels
{
    public class BankCreateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Agency { get; set; }
        public string? AccountNumber { get; set; }
        public int AccountTypeId { get; set; }
    }
}
