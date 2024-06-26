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

            string text = chatCompletion.Content.FirstOrDefault().Text;
            return text.Trim('`', '\n');
        }

        private List<ChatMessage> PrepareContextMessages(BinaryData imageBytes)
        {
            return new List<ChatMessage>
            {
                new UserChatMessage(
                new List<ChatMessageContentPart>
                {
                    ChatMessageContentPart.CreateTextMessageContentPart(
                        "Please return the data from this image as a Json object with the follow fields," +
                        "Description it should be a few words about this receipt," +
                        "Date it should be the date from the receipt, and should be in DateTime Format" +
                        "BankId it should be equals 1," +
                        "CategoryId it should be equals 1," +
                        "Amount it should be equals the total amount of the receipt," +
                        "RegisterTypeId it should be equals 1"),
                    ChatMessageContentPart.CreateImageMessageContentPart(imageBytes, "image/jpeg")
                })
            };
        }

        private RegisterModelCreate ParseToObject(string jsonString)
        {
            try
            {
                var jsonFomated = FormatJsonResult(jsonString);

                var register = JsonConvert.DeserializeObject<RegisterModelCreate>(jsonFomated);

                var registerFormated = FormatDate(register);

                if (registerFormated == null)
                {
                    throw new Exception("Deserialization returned null");
                }

                return registerFormated;
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

        private string FormatJsonResult(string jsonString)
        {
            if (jsonString.StartsWith("json\n"))
            {
                return jsonString = jsonString.Substring(5);
            }
            return jsonString;
        }

        private RegisterModelCreate FormatDate(RegisterModelCreate register)
        {
            var dataUTC = register.Date.ToUniversalTime();
            register.Date = dataUTC;

            return register;
        }
    }
}


