using FinancialManager.Application.Mappers;
using FinancialManager.Application.Services.Interface;
using FinancialManager.Application.Services.Service;
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
            services.AddScoped<IRegisterRepository, RegisterRepository>();
            services.AddScoped<IBankRepository, BankRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainToDtoMapping));
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<IBankService, BankService>();
            services.AddScoped<ICategoryService, CategoryService>();

            return services;
        }
    }
}
