using AutoMapper;
using FinancialManager.Application.ApiModels;
using FinancialManager.Application.Services.Interface;
using FinancialManager.Domain.Models;
using FinancialManager.Domain.Repositories.Interface;

namespace FinancialManager.Application.Services.Service
{
    public class AccountTypeService : IAccountTypeService
    {
        private readonly IEntitiesRepository<AccountType> _repository;
        private readonly IMapper _mapper;

        public AccountTypeService(IEntitiesRepository<AccountType> accountTypeRepository, IMapper mapper)
        {
            _repository = accountTypeRepository;
            _mapper = mapper;
        }

        public async Task<AccountTypeModel> CreateAsync(AccountTypeModel AccountTypeModel)
        {
            var accountType = _mapper.Map<AccountType>(AccountTypeModel);
            var data = await _repository.CreateAsync(accountType);

            return _mapper.Map<AccountTypeModel>(data);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var bank = await _repository.GetByIdAsync(id);

            return await _repository.DeleteAsync(id);

        }

        public async Task<ICollection<AccountTypeModel>> GetAsync()
        {
            var bank = await _repository.GetAsync();

            return _mapper.Map<ICollection<AccountTypeModel>>(bank);
        }

        public async Task<AccountTypeModel> GetByIdAsync(int id)
        {
            var bank = await _repository.GetByIdAsync(id);

            return _mapper.Map<AccountTypeModel>(bank);
        }

        public async Task UpdateAsync(int id, AccountTypeModel accountTypeModel)
        {
            var accountType = await _repository.GetByIdAsync(accountTypeModel.Id);

            await _repository.UpdateAsync(id, accountType);
        }
    }
}
