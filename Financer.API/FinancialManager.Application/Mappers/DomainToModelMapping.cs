using AutoMapper;
using FinancialManager.Application.DTOs;
using FinancialManager.Domain.Models;

namespace FinancialManager.Application.Mappers
{
    public class DomainToDtoMapping : Profile
    {
        public DomainToDtoMapping()
        {
            CreateMap<Bank, BankModel>();
            CreateMap<Category, CategoryModel>();
            CreateMap<Register, RegisterModel>();
            CreateMap<Register, RegisterDetailModel>()
                .ForMember(x => x.CategoryName, opt => opt.Ignore())
                .ForMember(x => x.BankName, opt => opt.Ignore())
                .ConstructUsing((model, context) =>
                {
                    var dto = new RegisterDetailModel
                    {
                        BankName = model.Bank.Name,
                        CategoryName = model.Category.Name,
                        Amount = model.Amount,
                        Date = model.Date,
                        Description = model.Description,
                        Id = model.Id,
                        RegisterType = model.RegisterType   
                    };
                    return dto;
                });
        }
    }
}
