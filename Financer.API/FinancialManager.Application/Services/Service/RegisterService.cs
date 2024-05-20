using AutoMapper;
using FinancialManager.Application.DTOs;
using FinancialManager.Application.DTOs.Validations;
using FinancialManager.Application.Services.Service;
using FinancialManager.Domain.Models;
using FinancialManager.Domain.Repositories.Interface;
using FinancialManager.Services.Interface;

namespace FinancialManager.Services.Service
{
    public class RegisterService : IRegisterService
    {
        private readonly IEntitiesRepository<Register> _registerRepository;
        private readonly IEntitiesRepository<Bank> _bankRepository;
        private readonly IEntitiesRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public RegisterService(IEntitiesRepository<Register> registerRepository, IEntitiesRepository<Bank> bankRepository, IEntitiesRepository<Category> categoryRepository, IMapper mapper)
        {
            _registerRepository = registerRepository;
            _bankRepository = bankRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<RegisterDto>> CreateAsync(RegisterDto registerDto)
        {
            if (registerDto == null)
                return ResultService.Fail<RegisterDto>("Objeto deve ser informado");

            var result = new RegisterDtoValidator().Validate(registerDto);

            if (!result.IsValid)
                return ResultService.RequestError<RegisterDto>("Erro de Validação!", result);

            var register = new Register(registerDto.Description, registerDto.Date, registerDto.BankId, registerDto.CategoryId, registerDto.Amount, registerDto.RegisterType);

            var data = await _registerRepository.CreateAsync(register);
            registerDto.Id = data.Id;

            return ResultService.Ok(registerDto);
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var register = await _registerRepository.GetByIdAsync(id);

            if (register == null)
                return ResultService.Fail("Registro não econtrado.");

            await _registerRepository.DeleteAsync(id);

            return ResultService.Ok($"Registro id:{id} foi deletado.");
        }

        public async Task<ResultService<ICollection<RegisterDetailDto>>> GetAsync()
        {
            var register = await _registerRepository.GetAsync();

            return ResultService.Ok(_mapper.Map<ICollection<RegisterDetailDto>>(register));
        }

        public async Task<ResultService<RegisterDetailDto>> GetByIdAsync(int id)
        {
            var register = await _registerRepository.GetByIdAsync(id);
            if (register == null)
                return ResultService.Fail<RegisterDetailDto>("Registro não encontrado!");
            

            return ResultService.Ok(_mapper.Map<RegisterDetailDto>(register));
        }

        public async Task<ResultService> UpdateAsync(int id, RegisterDto registerDto)
        {
            if (registerDto == null)
                return ResultService.Fail("Registro deve ser informado.");

            var validation = new RegisterDtoValidator().Validate(registerDto);

            if (validation.IsValid)
                return ResultService.RequestError("Problema com a validação dos campos.", validation);

            var register = await _registerRepository.GetByIdAsync(registerDto.Id);

            if (register == null)
                ResultService.Fail("Registro não encontrado.");

            
            register.Edit(register.Id, register.Description, register.Date, registerDto.BankId, registerDto.CategoryId, register.Amount, register.RegisterType);


            await _registerRepository.UpdateAsync(id, register);

            return ResultService.Ok("Update realizado.");
        }
    }
}
