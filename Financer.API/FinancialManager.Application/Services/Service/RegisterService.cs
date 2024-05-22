using AutoMapper;
using FinancialManager.Application.ApiModels;
using FinancialManager.Application.ApiModels.Validations;
using FinancialManager.Domain.Models;
using FinancialManager.Domain.Repositories.Interface;
using FinancialManager.Services.Interface;

namespace FinancialManager.Services.Service
{
    public class RegisterService : IRegisterService
    {
        private readonly IEntitiesRepository<Register> _registerRepository;
        private readonly IMapper _mapper;

        public RegisterService(IEntitiesRepository<Register> registerRepository, IMapper mapper)
        {
            _registerRepository = registerRepository;
            _mapper = mapper;
        }

        public async Task<RegisterModel> CreateAsync(RegisterModel registerModel)
        {
            var result = new RegisterModelValidator().Validate(registerModel);

            var register = new Register(registerModel.Description, registerModel.Date, registerModel.BankId, registerModel.CategoryId, registerModel.Amount, registerModel.RegisterTypeId);

            var data = await _registerRepository.CreateAsync(register);
            registerModel.Id = data.Id;

            return registerModel;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var register = await _registerRepository.GetByIdAsync(id);

            return await _registerRepository.DeleteAsync(register.Id);

        }

        public async Task<ICollection<RegisterModel>> GetAsync()
        {
            var register = await _registerRepository.GetAsync();

            return _mapper.Map<ICollection<RegisterModel>>(register);
        }

        public async Task<RegisterModel> GetByIdAsync(int id)
        {
            var register = await _registerRepository.GetByIdAsync(id);
            

            return _mapper.Map<RegisterModel>(register);
        }

        public async Task UpdateAsync(int id, RegisterModel registerDto)
        {
            var register = await _registerRepository.GetByIdAsync(registerDto.Id);
            
            register.Edit(register.Description, register.Date, registerDto.BankId, registerDto.CategoryId, register.Amount, register.RegisterTypeId);


            await _registerRepository.UpdateAsync(id, register);
        }
    }
}
