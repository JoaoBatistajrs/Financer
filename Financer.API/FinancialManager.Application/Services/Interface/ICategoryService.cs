﻿using FinancialManager.Application.DTOs;
using FinancialManager.Application.Services.Service;

namespace FinancialManager.Application.Services.Interface
{
    public interface ICategoryService
    {
        Task<ResultService<CategoryModel>> CreateAsync(CategoryModel categoryDto);
        Task<ResultService<ICollection<CategoryModel>>> GetAsync();
        Task<ResultService<CategoryModel>> GetByIdAsync(int id);
        Task<ResultService> UpdateAsync(int id, CategoryModel categoryDto);
        Task<ResultService> DeleteAsync(int id);
    }
}
