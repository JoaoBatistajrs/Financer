using AutoMapper;
using FinancialManager.Application.ApiModels;
using FinancialManager.Domain.Models;
using FinancialManager.Domain.Repositories.Interface;
using FinancialManager.Services.Interface;

namespace FinancialManager.Services.Service
{
    public class RegisterService : IRegisterService
    {
        private readonly IEntitiesRepository<Register> _genericRepository;
        private readonly IMapper _mapper;
        private readonly IRegisterRepository _registerRepository;

        public RegisterService(IEntitiesRepository<Register> genericRepository, IMapper mapper, IRegisterRepository registerRepository)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _registerRepository = registerRepository;
        }

        public async Task<RegisterModelCreate> CreateAsync(RegisterModelCreate registerModel)
        {
            var register = _mapper.Map<Register>(registerModel);
            var data = await _genericRepository.CreateAsync(register);

            return _mapper.Map<RegisterModelCreate>(data);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var register = await _genericRepository.GetByIdAsync(id);

            return await _genericRepository.DeleteAsync(register.Id);

        }

        public async Task<ICollection<RegisterDetailModel>> GetAsync()
        {
            var register = await _registerRepository.GetAsync();

            return _mapper.Map<ICollection<RegisterDetailModel>>(register);
        }

        public async Task<RegisterDetailModel> GetByIdAsync(int id)
        {
            var register = await _genericRepository.GetByIdAsync(id);
            
            return _mapper.Map<RegisterDetailModel>(register);
        }

        public async Task UpdateAsync(int id, RegisterModelCreate registerDto)
        {
            var register = await _genericRepository.GetByIdAsync(registerDto.Id);
            
            register.Edit(register.Description, register.Date, registerDto.BankId, registerDto.CategoryId, register.Amount, register.RegisterTypeId);


            await _genericRepository.UpdateAsync(id, register);
        }
    }
}
