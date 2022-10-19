using FinancialManager.Application.DTOs;
using FinancialManager.Application.Services.Interface;
using FinancialManager.Application.Services.Service;
using Microsoft.AspNetCore.Mvc;

namespace FinancialManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService service)
        {
            _categoryService = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddBank([FromBody] CategoryDto categoryDto)
        {
            var result = await _categoryService.CreateAsync(categoryDto);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _categoryService.GetAsync();

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _categoryService.GetByIdAsync(id);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBankAsync([FromBody] CategoryDto categoryDto)
        {
            var result = await _categoryService.UpdateAsync(categoryDto);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _categoryService.DeleteAsync(id);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
