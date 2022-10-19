using FinancialManager.Application.Mappers;
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
            
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainToDtoMapping));
            services.AddScoped<IRegisterService, RegisterService>();

            return services;
        }
    }
}
