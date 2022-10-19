using FinancialManager.Domain.Models;
using FinancialManager.Services.Interface;
using FinancialManager.Services.Service;
using Microsoft.AspNetCore.Mvc;

namespace FinancialManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly IRegisterService _registerService;

        public RegistersController(IRegisterService registerService)
        {
            _registerService = registerService;
        }


        [HttpPost]
        public IActionResult AddRegister(Register register)
        {
            
            return Ok(register);
        }

    }
}
