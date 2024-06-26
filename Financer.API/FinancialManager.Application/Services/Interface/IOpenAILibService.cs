using FinancialManager.Application.ApiModels;

namespace FinancialManager.Application.Services.Interface
{
    public interface IOpenAILibService
    {
        RegisterModelCreate GetRegisterFromImage(Stream imageStream);
    }
}
