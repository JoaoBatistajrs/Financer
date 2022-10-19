using AutoMapper;
using FinancialManager.Application.DTOs;
using FinancialManager.Application.DTOs.Validations;
using FinancialManager.Application.Services.Interface;
using FinancialManager.Domain.Models;
using FinancialManager.Domain.Repositories.Interface;
using FluentValidation;

namespace FinancialManager.Application.Services.Service
{
    public class BankService : IBankService
    {
        private readonly IBankRepository _bankRepository;
        private readonly IMapper _mapper;

        public BankService(IBankRepository bankRepository, IMapper mapper)
        {
            _bankRepository = bankRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<CategoryDto>> CreateAsync(CategoryDto bankDto)
        {
            if (bankDto == null)
                return ResultService.Fail<CategoryDto>("Objeto deve ser informado");

            var result = new BankDtoValidator().Validate(bankDto);

            if (!result.IsValid)
                return ResultService.RequestError<CategoryDto>("Erro de Validação!", result);

            var bank = _mapper.Map<Bank>(bankDto);
            var data = await _bankRepository.CreateAsync(bank);

            return ResultService.Ok<CategoryDto>(_mapper.Map<CategoryDto>(data));
        }
    }
}
