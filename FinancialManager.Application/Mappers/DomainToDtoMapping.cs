using AutoMapper;
using FinancialManager.Application.DTOs;
using FinancialManager.Domain.Models;

namespace FinancialManager.Application.Mappers
{
    public class DomainToDtoMapping : Profile
    {
        public DomainToDtoMapping()
        {
            CreateMap<Register, RegisterDto>();
            CreateMap<Bank, BankDto>();
            CreateMap<Category, CategoryDto>();
        }
    }
}
