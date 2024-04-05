using AutoMapper;
using FinancialManager.Application.DTOs;
using FinancialManager.Application.DTOs.Validations;
using FinancialManager.Application.Services.Interface;
using FinancialManager.Domain.Models;
using FinancialManager.Domain.Repositories.Interface;

namespace FinancialManager.Application.Services.Service
{
    public class BankService : IBankService
    {
        private readonly IEntitiesRepository<Bank> _repository;
        private readonly IMapper _mapper;

        public BankService(IEntitiesRepository<Bank> bankRepository, IMapper mapper)
        {
            _repository = bankRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<BankDto>> CreateAsync(BankDto bankDto)
        {
            if (bankDto == null)
                return ResultService.Fail<BankDto>("Objeto deve ser informado");

            var result = new BankDtoValidator().Validate(bankDto);

            if (!result.IsValid)
                return ResultService.RequestError<BankDto>("Erro de Validação!", result);

            var bank = _mapper.Map<Bank>(bankDto);
            var data = await _repository.CreateAsync(bank);

            return ResultService.Ok(_mapper.Map<BankDto>(data));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var bank = await _repository.GetByIdAsync(id);

            if (bank == null)
                return ResultService.Fail("Pessoa não econtrada.");

            await _repository.DeleteAsync(bank);
           
            return ResultService.Ok($"Pessoa do id:{id} foi deletada.");
        }

        public async Task<ResultService<ICollection<BankDto>>> GetAsync()
        {
            var bank = await _repository.GetAsync();
            
            return ResultService.Ok(_mapper.Map<ICollection<BankDto>>(bank));
        }

        public async Task<ResultService<BankDto>> GetByIdAsync(int id)
        {
            var bank = await _repository.GetByIdAsync(id);
            if (bank == null)
                return ResultService.Fail<BankDto>("Banco não encontrado!");

            return ResultService.Ok(_mapper.Map<BankDto>(bank));
        }

        public async Task<ResultService> UpdateAsync(int id, BankDto bankDto)
        {
            if (bankDto == null)
                return ResultService.Fail("Banco deve ser informado.");
            
            var validation = new BankDtoValidator().Validate(bankDto);

            if (validation.IsValid)
                return ResultService.RequestError("Problema com a validação dos campos.", validation);

            var bank = await _repository.GetByIdAsync(bankDto.Id);

            if(bank == null)
                ResultService.Fail("Banco não encontrado.");

            bank = _mapper.Map<BankDto, Bank>(bankDto, bank);

            await _repository.UpdateAsync(id, bank);

            return ResultService.Ok("Update realizado.");
        }
    }
}
