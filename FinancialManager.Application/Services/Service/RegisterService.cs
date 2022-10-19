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
        private readonly IMapper _mapper;

        public RegisterService(IRegisterRepository registerRepository, IMapper mapper)
        {
            _registerRepository = registerRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<RegisterDto>> CreateAsync(RegisterDto registerDto)
        {
            if (registerDto == null)
                return ResultService.Fail<RegisterDto>("Objeto deve ser informado");

            var result = new RegisterDtoValidator().Validate(registerDto);

            if (!result.IsValid)
                return ResultService.RequestError<RegisterDto>("Erro de Validação!", result);

            var register = _mapper.Map<Register>(registerDto);
            var data = await _registerRepository.CreateAsync(register);

            return ResultService.Ok<RegisterDto>(_mapper.Map<RegisterDto>(data));
        }
    }
}
