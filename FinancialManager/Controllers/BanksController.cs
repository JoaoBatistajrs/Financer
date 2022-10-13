using FinancialManager.Data;
using FinancialManager.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinancialManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        private readonly FinancialManagerDbContext dbContext;

        public BanksController(FinancialManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetBanks()
        {
            return Ok(await dbContext.Banks.ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetBank([FromRoute] Guid id)
        {
            var bank = await dbContext.Banks.FindAsync(id);

            if (bank != null)
            {
                return Ok(bank);

            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddBank(BankRequest bankRequest)
        {
            var bank = new Bank()
            {
                Id = Guid.NewGuid(),
                Name = bankRequest.Name,
                Agency = bankRequest.Agency,
                AccountNumber = bankRequest.AccountNumber,
                AccountType = bankRequest.AccountType
                
            };

            await dbContext.Banks.AddAsync(bank);
            await dbContext.SaveChangesAsync();

            return Ok(bank);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateBanks([FromRoute] Guid id, BankRequest bankRequest)
        {
            var bank = await dbContext.Banks.FindAsync(id);

            if (bank != null)
            {
                bank.Name = bankRequest.Name;
                bank.Agency = bankRequest.Agency;
                bank.AccountNumber = bankRequest.AccountNumber;
                bank.AccountType = bankRequest.AccountType;

                dbContext.SaveChangesAsync();

                return Ok(bank);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteBank([FromRoute] Guid id)
        {
            var bank = await dbContext.Banks.FindAsync(id);

            if (bank != null)
            {
                dbContext.Remove(bank);
                await dbContext.SaveChangesAsync();
                return Ok(bank);
            }

            return NotFound();
        }
    }
}
