using AutoMapper;
using FinancialManager.Application.ApiModels;
using FinancialManager.Domain.Models;

namespace FinancialManager.Application.Mappers
{
    public class DomainToModelMapping : Profile
    {
        public DomainToModelMapping()
        {
            CreateMap<Bank, BankModel>();
            CreateMap<Bank, BankCreateModel>();
            CreateMap<Category, CategoryModel>().ForMember(dest => dest.ExpenseTypeName, opt => opt.MapFrom(src => src.Type.Name));
            CreateMap<Category, CategoryModelCreate>();
            CreateMap<RegisterType, RegisterTypeModel>();
            CreateMap<ExpenseType, ExpenseTypeModel>();
            CreateMap<Register, RegisterModelCreate>();
            CreateMap<Register, RegisterDetailModel>()
                .ForMember(dest => dest.BankName, opt => opt.MapFrom(src => src.Bank.Name))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.RegisterTypeName, opt => opt.MapFrom(src => src.RegisterType.Name));
        }
    }
}
