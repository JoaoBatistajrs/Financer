using AutoMapper;
using FinancialManager.Application.ApiModels;
using FinancialManager.Application.ApiModels.Validations;
using FinancialManager.Application.Services.Interface;
using FinancialManager.Domain.Models;
using FinancialManager.Domain.Repositories.Interface;

namespace FinancialManager.Application.Services.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IEntitiesRepository<Category> _repository;
        private readonly IMapper _mapper; 

        public CategoryService(IEntitiesRepository<Category> categoryRepository, IMapper mapper)
        {
            _repository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<CategoryModel>> CreateAsync(CategoryModel categoryDto)
        {
            if (categoryDto == null)
                return ResultService.Fail<CategoryModel>("Objeto deve ser informado");

            var result = new CategoryModelValidator().Validate(categoryDto);

            if (!result.IsValid)
                return ResultService.RequestError<CategoryModel>("Erro de Validação!", result);

            var category = _mapper.Map<Category>(categoryDto);
            var data = await _repository.CreateAsync(category);

            return ResultService.Ok(_mapper.Map<CategoryModel>(data));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);

            if (category == null)
                return ResultService.Fail("Categoria não econtrada.");

            await _repository.DeleteAsync(id);

            return ResultService.Ok($"Categoria id:{id} foi deletada.");
        }

        public async Task<ResultService<ICollection<CategoryModel>>> GetAsync()
        {
            var category = await _repository.GetAsync();

            return ResultService.Ok(_mapper.Map<ICollection<CategoryModel>>(category));
        }

        public async Task<ResultService<CategoryModel>> GetByIdAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category == null)
                return ResultService.Fail<CategoryModel>("Categoria não encontrada!");

            return ResultService.Ok(_mapper.Map<CategoryModel>(category));
        }

        public async Task<ResultService> UpdateAsync(int id, CategoryModel categoryDto)
        {
            if (categoryDto == null)
                return ResultService.Fail("Categoria deve ser informado.");

            var validation = new CategoryModelValidator().Validate(categoryDto);

            if (validation.IsValid)
                return ResultService.RequestError("Problema com a validação dos campos.", validation);

            var category = await _repository.GetByIdAsync(categoryDto.Id);

            if (category == null)
                ResultService.Fail("Categoria não encontrada.");

            category = _mapper.Map<CategoryModel, Category>(categoryDto, category);

            await _repository.UpdateAsync(id, category);

            return ResultService.Ok("Update realizado.");
        }
    }
}
