using FinancialManager.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FinancialManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatGptController : Controller
    {
        private readonly IChatGptService _chatGptService;

        public ChatGptController(IChatGptService service)
        {
            _chatGptService = service;
        }

        [HttpPost("send-request")]
        public async Task<IActionResult> SendRequest([FromBody] UserRequest request)
        {
            if (string.IsNullOrEmpty(request.Content))
            {
                return BadRequest("Request content cannot be empty.");
            }

            var response = await _chatGptService.SendRequestAsync(request.Content);
            return Ok(new { response });
        }
    }
}

public class UserRequest
{
    public string Content { get; set; }
}
