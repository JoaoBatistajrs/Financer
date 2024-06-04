
using FinancialManager.Application.ApiModels;
using FinancialManager.Application.Services.Interface;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace FinancialManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        private readonly IBankService _bankService;

        public BanksController(IBankService service)
        {
            _bankService = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddBankAsync([FromBody] BankCreateModel bankModel)
        {
            try
            {
                var result = await _bankService.CreateAsync(bankModel);
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
            var result = await _bankService.GetAsync();

            if (result != null)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _bankService.GetByIdAsync(id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateBankAsync(int id, [FromBody] BankModel bankModel)
        {
            try
            {
                await _bankService.UpdateAsync(id, bankModel);

                var updatedBank = await _bankService.GetByIdAsync(id);

                if (updatedBank != null)
                {
                    return Ok(updatedBank);
                }

                return NotFound($"Bank with ID {id} not found.");
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
                var result = await _bankService.DeleteAsync(id);

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
