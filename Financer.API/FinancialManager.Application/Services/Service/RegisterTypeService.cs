using AutoMapper;
using FinancialManager.Application.ApiModels;
using FinancialManager.Application.Services.Interface;
using FinancialManager.Domain.Models;
using FinancialManager.Domain.Repositories.Interface;

namespace FinancialManager.Application.Services.Service
{
    public class RegisterTypeService : IRegisterTypeService
    {
        private readonly IEntitiesRepository<RegisterType> _repository;
        private readonly IMapper _mapper;

        public RegisterTypeService(IEntitiesRepository<RegisterType> registerTypeRepository, IMapper mapper)
        {
            _repository = registerTypeRepository;
            _mapper = mapper;
        }

        public async Task<RegisterTypeModel> CreateAsync(RegisterTypeModel registerTypeModel)
        {
            var registerType = _mapper.Map<RegisterType>(registerTypeModel);
            var data = await _repository.CreateAsync(registerType);

            return _mapper.Map<RegisterTypeModel>(data);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var expense = await _repository.GetByIdAsync(id);

            return await _repository.DeleteAsync(expense.Id);

        }

        public async Task<ICollection<RegisterTypeModel>> GetAsync()
        {
            var registerType = await _repository.GetAsync();

            return _mapper.Map<ICollection<RegisterTypeModel>>(registerType);
        }

        public async Task<RegisterTypeModel> GetByIdAsync(int id)
        {
            var registerType = await _repository.GetByIdAsync(id);

            return _mapper.Map<RegisterTypeModel>(registerType);
        }

        public async Task UpdateAsync(int id, RegisterTypeModel registerTypeModel)
        {
            var registerType = await _repository.GetByIdAsync(registerTypeModel.Id);

            await _repository.UpdateAsync(id, registerType);
        }
    }
}