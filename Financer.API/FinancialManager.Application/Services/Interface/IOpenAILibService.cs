using FinancialManager.Application.ApiModels;
using OpenAI.Chat;

namespace FinancialManager.Application.Services.Interface
{
    public interface IOpenAILibService
    {
        Task<ChatMessageContentPart> CallChatStreamimg();
        RegisterModelCreate GetRegisterFromImage();
    }
}
