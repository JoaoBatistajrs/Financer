using AutoMapper;
using FinancialManager.Application.ApiModels;
using FinancialManager.Application.Services.Interface;
using FinancialManager.Domain.Models;
using FinancialManager.Domain.Repositories.Interface;

namespace FinancialManager.Application.Services.Service
{
    public class ExpenseTypeService : IExpenseTypeService
    {
        private readonly IEntitiesRepository<ExpenseType> _repository;
        private readonly IMapper _mapper;

        public ExpenseTypeService(IEntitiesRepository<ExpenseType> expenseTypeRepository, IMapper mapper)
        {
            _repository = expenseTypeRepository;
            _mapper = mapper;
        }

        public async Task<ExpenseTypeModel> CreateAsync(ExpenseTypeModel expenseTypeModel)
        {
            var expenseType = _mapper.Map<ExpenseType>(expenseTypeModel);
            var data = await _repository.CreateAsync(expenseType);

            return _mapper.Map<ExpenseTypeModel>(data);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var expense = await _repository.GetByIdAsync(id);

            return await _repository.DeleteAsync(expense.Id);

        }

        public async Task<ICollection<ExpenseTypeModel>> GetAsync()
        {
            var expense = await _repository.GetAsync();

            return _mapper.Map<ICollection<ExpenseTypeModel>>(expense);
        }

        public async Task<ExpenseTypeModel> GetByIdAsync(int id)
        {
            var expense = await _repository.GetByIdAsync(id);

            return _mapper.Map<ExpenseTypeModel>(expense);
        }

        public async Task UpdateAsync(int id, ExpenseTypeModel expenseTypeModel)
        {
            var expenseType = _mapper.Map<ExpenseType>(expenseTypeModel);

            await _repository.UpdateAsync(id, expenseType);
        }
    }
}
