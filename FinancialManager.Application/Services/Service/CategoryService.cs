using AutoMapper;
using FinancialManager.Application.DTOs;
using FinancialManager.Application.DTOs.Validations;
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

            var result = new CategoryDtoValidator().Validate(categoryDto);

            if (!result.IsValid)
                return ResultService.RequestError<CategoryDto>("Erro de Validação!", result);

            var category = _mapper.Map<Category>(categoryDto);
            var data = await _categoryRepository.CreateAsync(category);

            return ResultService.Ok(_mapper.Map<CategoryDto>(data));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            if (category == null)
                return ResultService.Fail("Categoria não econtrada.");

            await _categoryRepository.DeleteAsync(category);

            return ResultService.Ok($"Categoria id:{id} foi deletada.");
        }

        public async Task<ResultService<ICollection<CategoryDto>>> GetAsync()
        {
            var category = await _categoryRepository.GetCategoryAsync();

            return ResultService.Ok(_mapper.Map<ICollection<CategoryDto>>(category));
        }

        public async Task<ResultService<CategoryDto>> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
                return ResultService.Fail<CategoryDto>("Categoria não encontrada!");

            return ResultService.Ok(_mapper.Map<CategoryDto>(category));
        }

        public async Task<ResultService> UpdateAsync(CategoryDto categoryDto)
        {
            if (categoryDto == null)
                return ResultService.Fail("Categoria deve ser informado.");

            var validation = new CategoryDtoValidator().Validate(categoryDto);

            if (validation.IsValid)
                return ResultService.RequestError("Problema com a validação dos campos.", validation);

            var category = await _categoryRepository.GetByIdAsync(categoryDto.Id);

            if (category == null)
                ResultService.Fail("Categoria não encontrada.");

            category = _mapper.Map<CategoryDto, Category>(categoryDto, category);

            await _categoryRepository.UpdateAsync(category);

            return ResultService.Ok("Update realizado.");
        }
    }
}
