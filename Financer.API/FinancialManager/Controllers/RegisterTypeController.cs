using FinancialManager.Application.ApiModels;
using FinancialManager.Application.Services.Interface;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace FinancialManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterTypeController : ControllerBase
    {
        private readonly IRegisterTypeService _registerTypeService;

        public RegisterTypeController(IRegisterTypeService service)
        {
            _registerTypeService = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddRegisterTypeAsync([FromBody] RegisterTypeModel registerTypeModel)
        {
            try
            {
                var result = await _registerTypeService.CreateAsync(registerTypeModel);
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
            var result = await _registerTypeService.GetAsync();

            if (result != null)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _registerTypeService.GetByIdAsync(id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateExpenseTypeAsync(int id, [FromBody] RegisterTypeModel registerTypeModel)
        {
            try
            {
                await _registerTypeService.UpdateAsync(id, registerTypeModel);

                var result = await _registerTypeService.GetByIdAsync(id);

                if (result != null)
                {
                    return Ok(result);
                }

                return NotFound($"Register Type with ID {id} not found.");
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
                var result = await _registerTypeService.DeleteAsync(id);

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
