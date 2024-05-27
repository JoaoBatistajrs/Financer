using AutoMapper;
using FinancialManager.Application.ApiModels;
using FinancialManager.Domain.Models;

namespace FinancialManager.Application.Mappers
{
    public class ModelToDomainMapping : Profile
    {
        public ModelToDomainMapping()
        {
            CreateMap<RegisterModel, Register>();
            CreateMap<BankModel, Bank>();
            CreateMap<BankCreateModel, Bank>();
            CreateMap<CategoryModel, Category>();
            CreateMap<ExpenseTypeModel, ExpenseType>();
            CreateMap<RegisterTypeModel, RegisterType>();
        }
    }
}
