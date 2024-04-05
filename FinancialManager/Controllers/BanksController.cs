﻿using FinancialManager.Application.DTOs;
using FinancialManager.Application.Services.Interface;
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
        public async Task<IActionResult> AddBankAsync([FromBody] BankDto bankDto)
        {
            var result = await _bankService.CreateAsync(bankDto);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _bankService.GetAsync();

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _bankService.GetByIdAsync(id);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBankAsync(int id, [FromBody] BankDto bankDto)
        {
            var result = await _bankService.UpdateAsync(id, bankDto);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _bankService.DeleteAsync(id);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

    }
}
