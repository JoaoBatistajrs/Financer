using AutoMapper;
using FinancialManager.Application.DTOs;
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

        public async Task<BankDto> CreateAsync(BankDto bankDto)
        {
            var bank = _mapper.Map<Bank>(bankDto);
            var data = await _repository.CreateAsync(bank);

            return _mapper.Map<BankDto>(data);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var bank = await _repository.GetByIdAsync(id);

            return await _repository.DeleteAsync(id);
           
        }

        public async Task<ICollection<BankDto>> GetAsync()
        {
            var bank = await _repository.GetAsync();
            
            return _mapper.Map<ICollection<BankDto>>(bank);
        }

        public async Task<BankDto> GetByIdAsync(int id)
        {
            var bank = await _repository.GetByIdAsync(id);

            return _mapper.Map<BankDto>(bank);
        }

        public async Task UpdateAsync(int id, BankDto bankDto)
        {
            var bank = await _repository.GetByIdAsync(bankDto.Id);

            await _repository.UpdateAsync(id, bank);
        }
    }
}
