using HelpDesk.Api.Application.Interfaces.Repositories;
using HelpDesk.Infrastructure.Persistance.Context;
using HelpDesk.Infrastructure.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HelpDesk.Infrastructure.Persistance.Extensions
{
    public static class Registration
    {
        public static IServiceCollection AddPersistanceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDemandRepository, DemandRepository>();
            services.AddScoped<IDemandMessageRepository, DemandMessageRepository>();

            return services;
        }
    }
}
