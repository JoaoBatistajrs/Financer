using FinancialManager.Application.ApiModels;
using FinancialManager.Application.Services.Interface;
using Newtonsoft.Json;
using OpenAI.Chat;

namespace FinancialManager.Application.Services.Service
{
    public class OpenAILibService : IOpenAILibService
    {
        public RegisterModelCreate GetRegisterFromImage(Stream imageStream)
        {
            var imageResult = ConvertImageToJson(imageStream);
            var result = ParseToObject(imageResult);
            return result;
        }

        private string ConvertImageToJson(Stream imageStream)
        {
            ChatClient client = new(model: "gpt-4o", "");

            BinaryData imageBytes = BinaryData.FromStream(imageStream);

            List<ChatMessage> messages = PrepareContextMessages(imageBytes);

            ChatCompletion chatCompletion = client.CompleteChat(messages);

            return chatCompletion.Content.FirstOrDefault().Text;
        }

        private List<ChatMessage> PrepareContextMessages(BinaryData imageBytes)
        {
            return new List<ChatMessage>
            {
                new SystemChatMessage(DefineSystemMessages()),
                new UserChatMessage(DefineUserChatMessages(imageBytes)),
            };
        }

        private RegisterModelCreate ParseToObject(string jsonString)
        {
            try
            {
                var register = JsonConvert.DeserializeObject<RegisterModelCreate>(jsonString);

                if (register == null)
                {
                    throw new Exception("Deserialization returned null");
                }

                return register;
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"Error parsing JSON: {jsonEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        private List<ChatMessageContentPart> DefineUserChatMessages(BinaryData imageBytes)
        {
            return new List<ChatMessageContentPart>
            {
                ChatMessageContentPart.CreateTextMessageContentPart(
                    "Please validate this image"
                ),
                ChatMessageContentPart.CreateImageMessageContentPart(imageBytes, "image/jpeg")
            };
        }

        private string DefineSystemMessages()
        {
            return "You are going to receive images of receipts, " +
                   "and should return an output as a JSON object with the following fields: " +
                   "Description (a few words about this receipt), " +
                   "Date (the date from the receipt, in UTC DateTime Format), " +
                   "BankId (always 1), " +
                   "CategoryId (always 1), " +
                   "Amount (the total amount of the receipt), " +
                   "RegisterTypeId (always 1). " +
                   "You must only show the output object; do not include the string name 'json'.";
        }

    }
}


