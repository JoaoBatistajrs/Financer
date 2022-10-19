using AutoMapper;
using FinancialManager.Application.DTOs;
using FinancialManager.Domain.Models;

namespace FinancialManager.Application.Mappers
{
    public class DtoToDomainMapping : Profile
    {
        public DtoToDomainMapping()
        {
            CreateMap<RegisterDto, Register>();
            CreateMap<BankDto, Bank>();
            CreateMap<CategoryDto, Category>();
        }
    }
}
