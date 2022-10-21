using FinancialManager.Application.DTOs;
using FinancialManager.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FinancialManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("token")]
        public async Task<IActionResult> AddAsync([FromForm] UserDto userDto)
        {
            var result = await _userService.GenerateTokenAsync(userDto);
            
            if(result.IsSuccess)
                return Ok(result.Data);  
            
            return BadRequest(result);
        }
    }
}
