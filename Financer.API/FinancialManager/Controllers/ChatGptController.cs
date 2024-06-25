using FinancialManager.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FinancialManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatGptController : Controller
    {
        private readonly IOpenAILibService _openAILibService; 
        public ChatGptController(IOpenAILibService openIALibService)
        {
            _openAILibService = openIALibService; 
        }

        [HttpGet("chat")]
        public async Task<IActionResult> SendRequest()
        {
            var result = await _openAILibService.CallChatStreamimg();

            return Ok(result);
        }

        [HttpGet("image-read")]
        public async Task<IActionResult> ReadImage()
        {
            var result =  _openAILibService.GetRegisterFromImage();

            return Ok(result);
        }

    }
}