using FinancialManager.Application.ApiModels;
using FinancialManager.Application.Services.Interface;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace FinancialManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTypeController : ControllerBase
    {
        private readonly IAccountTypeService _accountTypeService;

        public AccountTypeController(IAccountTypeService service)
        {
            _accountTypeService = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddAccountTypeAsync([FromBody] AccountTypeModel accountTypeModel)
        {
            try
            {
                var result = await _accountTypeService.CreateAsync(accountTypeModel);
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
            var result = await _accountTypeService.GetAsync();

            if (result != null)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _accountTypeService.GetByIdAsync(id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAccountTypeAsync(int id, [FromBody] AccountTypeModel accountTypeModel)
        {
            try
            {
                await _accountTypeService.UpdateAsync(id, accountTypeModel);

                var result = await _accountTypeService.GetByIdAsync(id);

                if (result != null)
                {
                    return Ok(result);
                }

                return NotFound($"Account Type with ID {id} not found.");
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
                var result = await _accountTypeService.DeleteAsync(id);

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
