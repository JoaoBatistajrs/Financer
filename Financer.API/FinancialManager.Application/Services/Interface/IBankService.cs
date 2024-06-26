﻿using FinancialManager.Application.ApiModels;

namespace FinancialManager.Application.Services.Interface
{
    public interface IBankService
    {
        Task<BankCreateModel> CreateAsync(BankCreateModel bankModel);
        Task<ICollection<BankModel>> GetAsync();
        Task<BankModel> GetByIdAsync(int id);
        Task UpdateAsync(int id, BankModel bankModel);
        Task<bool> DeleteAsync(int id);
    }
}
