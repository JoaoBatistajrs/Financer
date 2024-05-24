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

        public async Task<CategoryModel> CreateAsync(CategoryModel categoryDto)
        {

            var category = _mapper.Map<Category>(categoryDto);
            var data = await _repository.CreateAsync(category);

            return _mapper.Map<CategoryModel>(data);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);

            if (category == null)
                return false;

            return await _repository.DeleteAsync(id);
        }

        public async Task<ICollection<CategoryModel>> GetAsync()
        {
            var category = await _repository.GetAsync();

            return _mapper.Map<ICollection<CategoryModel>>(category);
        }

        public async Task<CategoryModel> GetByIdAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);

            return _mapper.Map<CategoryModel>(category);
        }

        public async Task UpdateAsync(int id, CategoryModel categoryDto)
        {
            var validation = new CategoryModelValidator().Validate(categoryDto);

            var category = await _repository.GetByIdAsync(categoryDto.Id);

            await _repository.UpdateAsync(id, category);
        }
    }
}
