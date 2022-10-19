using AutoMapper;
using FinancialManager.Application.DTOs.Validations;
using FinancialManager.Application.DTOs;
using FinancialManager.Application.Services.Interface;
using FinancialManager.Domain.Models;
using FinancialManager.Domain.Repositories.Interface;

namespace FinancialManager.Application.Services.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<CategoryDto>> CreateAsync(CategoryDto categoryDto)
        {
            if (categoryDto == null)
                return ResultService.Fail<CategoryDto>("Objeto deve ser informado");

            var result = new BankDtoValidator().Validate(categoryDto);

            if (!result.IsValid)
                return ResultService.RequestError<CategoryDto>("Erro de Validação!", result);

            var bank = _mapper.Map<Category>(categoryDto);
            var data = await _categoryRepository.CreateAsync(bank);

            return ResultService.Ok<CategoryDto>(_mapper.Map<CategoryDto>(data));
        }
    }
}
