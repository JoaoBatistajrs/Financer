using FinancialManager.Application.Services.Interface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManager.Application.Services.Service
{
    public class ChatGptService : IChatGptService
    {
        private readonly HttpClient _httpClient;

        private const string Endpoint = "https://api.openai.com/v1/chat/completions";
        private const string Model = "gpt-3.5-turbo";
        private const double Temperature = 0.7;

        public ChatGptService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> SendRequestAsync(string userRequest)
        {
            try
            {
                var messages = new[]
                {
                    new { role = "user", content = userRequest },
                };

                var data = new
                {
                    model = Model,
                    messages,
                    temperature = Temperature
                };

                var jsonString = JsonConvert.SerializeObject(data);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var result = await _httpClient.PostAsync(Endpoint, content);

                var responseContent = await result.Content.ReadAsStringAsync();

                if (result.IsSuccessStatusCode)
                {
                    var jsonResponse = JObject.Parse(responseContent);
                    return jsonResponse["choices"]?[0]?["message"]?["content"]?.Value<string>() ?? "No response content";
                }
                else
                {
                    var errorResponse = JObject.Parse(responseContent);
                    var errorMessage = errorResponse["error"]?["message"]?.Value<string>() ?? "Unknown error";
                    return $"Error: {errorMessage}";
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
