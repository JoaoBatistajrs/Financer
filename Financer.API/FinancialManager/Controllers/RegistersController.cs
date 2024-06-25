using FinancialManager.Application.ApiModels;
using FinancialManager.Application.Services.Interface;
using FinancialManager.Services.Interface;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace FinancialManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly IRegisterService _registerService;
        private readonly IOpenAILibService _openAILibService;

        public RegistersController(IRegisterService registerService, IOpenAILibService openAILibService)
        {
            _registerService = registerService;
            _openAILibService = openAILibService;
        }


        [HttpPost]
        public async Task<IActionResult> AddRegisterAsync([FromBody] RegisterModelCreate registerModel)
        {
            try
            {
                var result = await _registerService.CreateAsync(registerModel);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { Errors = ex.Errors });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");

            }
        }

        [HttpPost("add-with-image")]
        public async Task<IActionResult> AddRegisterAsync(IFormFile file)
        {
            try
            {
                var registerModel = _openAILibService.GetRegisterFromImage(file.OpenReadStream());
              
                var result = await _registerService.CreateAsync(registerModel);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { Errors = ex.Errors });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");

            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _registerService.GetAsync();

            if (result != null)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _registerService.GetByIdAsync(id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateBankAsync(int id, [FromBody] RegisterModelCreate registerModel)
        {
            try
            {
                await _registerService.UpdateAsync(id, registerModel);

                var updatedBank = await _registerService.GetByIdAsync(id);

                if (updatedBank != null)
                {
                    return Ok(updatedBank);
                }

                return NotFound($"Register with ID {id} not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");

            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var result = await _registerService.DeleteAsync(id);

                if (!result)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");

            }
        }
    }
}
