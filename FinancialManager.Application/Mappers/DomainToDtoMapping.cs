using AutoMapper;
using FinancialManager.Application.DTOs;
using FinancialManager.Domain.Models;

namespace FinancialManager.Application.Mappers
{
    public class DomainToDtoMapping : Profile
    {
        public DomainToDtoMapping()
        {
            CreateMap<Bank, BankDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Register, RegisterDto>();
            CreateMap<Register, RegisterDetailDto>()
                .ForMember(x => x.CategoryName, opt => opt.Ignore())
                .ForMember(x => x.BankName, opt => opt.Ignore())
                .ConstructUsing((model, context) =>
                {
                    var dto = new RegisterDetailDto
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
