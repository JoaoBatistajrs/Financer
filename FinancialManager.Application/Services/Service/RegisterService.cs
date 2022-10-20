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
        private readonly IRegisterRepository _registerRepository;
        private readonly IBankRepository _bankRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public RegisterService(IRegisterRepository registerRepository, IBankRepository bankRepository, ICategoryRepository categoryRepository, IMapper mapper)
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

            var bankId = await _bankRepository.GetIdByName(registerDto.BankName);
            var categoryId = await _categoryRepository.GetIdByName(registerDto.CategoryName);
            var register = new Register(registerDto.Description, registerDto.Date, bankId, categoryId, registerDto.Amount, registerDto.RegisterType);

            var data = await _registerRepository.CreateAsync(register);
            registerDto.Id = data.Id;

            return ResultService.Ok(registerDto);
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var register = await _registerRepository.GetByIdAsync(id);

            if (register == null)
                return ResultService.Fail("Registro não econtrado.");

            await _registerRepository.DeleteAsync(register);

            return ResultService.Ok($"Registro id:{id} foi deletado.");
        }

        public async Task<ResultService<ICollection<RegisterDto>>> GetAsync()
        {
            var register = await _registerRepository.GetRegistersAsync();

            return ResultService.Ok(_mapper.Map<ICollection<RegisterDto>>(register));
        }

        public async Task<ResultService<RegisterDto>> GetByIdAsync(int id)
        {
            var register = await _registerRepository.GetByIdAsync(id);
            if (register == null)
                return ResultService.Fail<RegisterDto>("Registro não encontrado!");
            

            return ResultService.Ok(_mapper.Map<RegisterDto>(register));
        }

        public async Task<ResultService> UpdateAsync(RegisterDto registerDto)
        {
            if (registerDto == null)
                return ResultService.Fail("Registro deve ser informado.");

            var validation = new RegisterDtoValidator().Validate(registerDto);

            if (validation.IsValid)
                return ResultService.RequestError("Problema com a validação dos campos.", validation);

            var register = await _registerRepository.GetByIdAsync(registerDto.Id);

            if (register == null)
                ResultService.Fail("Registro não encontrado.");

            register = _mapper.Map<RegisterDto, Register>(registerDto, register);

            await _registerRepository.UpdateAsync(register);

            return ResultService.Ok("Update realizado.");
        }
    }
}
