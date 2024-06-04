using FinancialManager.Application.ApiModels;
using FinancialManager.Application.Services.Interface;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace FinancialManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseTypeController : ControllerBase
    {
        private readonly IExpenseTypeService _expenseTypeService;

        public ExpenseTypeController(IExpenseTypeService service)
        {
            _expenseTypeService = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddExpenseTypeAsync([FromBody] ExpenseTypeModel expenseTypeModel)
        {
            try
            {
                var result = await _expenseTypeService.CreateAsync(expenseTypeModel);
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
            var result = await _expenseTypeService.GetAsync();

            if (result != null)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _expenseTypeService.GetByIdAsync(id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateExpenseTypeAsync(int id, [FromBody] ExpenseTypeModel expenseTypeModel)
        {
            try
            {
                await _expenseTypeService.UpdateAsync(id, expenseTypeModel);

                var result = await _expenseTypeService.GetByIdAsync(id);

                if (result != null)
                {
                    return Ok(result);
                }

                return NotFound($"Expense Type with ID {id} not found.");
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
                var result = await _expenseTypeService.DeleteAsync(id);

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
