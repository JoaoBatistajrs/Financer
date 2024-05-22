using FinancialManager.Application.Mappers;
using FinancialManager.Application.Services.Interface;
using FinancialManager.Application.Services.Service;
using FinancialManager.Domain.Models;
using FinancialManager.Domain.Repositories.Interface;
using FinancialManager.InfraStructure.Context;
using FinancialManager.InfraStructure.Repositories;
using FinancialManager.Services.Interface;
using FinancialManager.Services.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialManager.IoC
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfraStrucuture(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FinancialManagerDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("FinancerApiConnectionString")));

            services.AddScoped<IEntitiesRepository<Register>, EntitiesRepository<Register>> ();
            services.AddScoped<IEntitiesRepository<Bank>, EntitiesRepository<Bank>>();
            services.AddScoped<IEntitiesRepository<Category>, EntitiesRepository<Category>>();
            services.AddScoped<IEntitiesRepository<AccountType>, EntitiesRepository<AccountType>>();
            services.AddScoped<IEntitiesRepository<ExpenseType>, EntitiesRepository<ExpenseType>>();
            services.AddScoped<IEntitiesRepository<RegisterType>, EntitiesRepository<RegisterType>>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainToModelMapping));
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<IBankService, BankService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IAccountTypeService, AccountTypeService>();
            services.AddScoped<IExpenseTypeService, ExpenseTypeService>();
            services.AddScoped<IRegisterTypeService, RegisterTypeService>();

            return services;
        }
    }
}
