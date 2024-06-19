namespace FinancialManager.Application.Services.Interface
{
    public interface IChatGptService
    {
        Task<string> SendRequestAsync(string userRequest);
    }
}
