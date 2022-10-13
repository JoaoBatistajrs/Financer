using FinancialManager.Data;
using FinancialManager.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinancialManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly FinancialManagerDbContext dbContext;

        public CategoriesController(FinancialManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await dbContext.Categories.ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetCategory([FromRoute] Guid id)
        {
            var category = await dbContext.Categories.FindAsync(id);

            if (category != null)
            {
                return Ok(category);

            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategories(CategoryRequest addCategoryRequest)
        {
            var category = new Category()
            {
                Id = Guid.NewGuid(),
                Name = addCategoryRequest.Name,
                Type = addCategoryRequest.Type,
            };

            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();

            return Ok(category);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateCategories([FromRoute] Guid id, CategoryRequest updateCategoryRequest)
        {
            var category = await dbContext.Categories.FindAsync(id);

            if (category != null)
            {
                category.Name = updateCategoryRequest.Name;

                dbContext.SaveChangesAsync();

                return Ok(category);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] Guid id)
        {
            var category = await dbContext.Categories.FindAsync(id);

            if (category != null)
            {
                dbContext.Remove(category);
                await dbContext.SaveChangesAsync();
                return Ok(category);
            }

            return NotFound();
        }
    }
}
