using AutoMapper;
using FinancialManager.Application.ApiModels;
using FinancialManager.Domain.Models;

namespace FinancialManager.Application.Mappers
{
    public class ModelToDomainMapping : Profile
    {
        public ModelToDomainMapping()
        {
            CreateMap<RegisterModelCreate, Register>();
            CreateMap<RegisterDetailModel, Register>();

            CreateMap<BankModel, Bank>();
            CreateMap<BankCreateModel, Bank>();

            CreateMap<CategoryModelCreate, Category>();
            CreateMap<CategoryModel, Category>();

            CreateMap<ExpenseTypeModel, ExpenseType>();

            CreateMap<RegisterTypeModel, RegisterType>();
        }
    }
}
