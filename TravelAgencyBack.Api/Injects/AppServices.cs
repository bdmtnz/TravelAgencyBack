using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TravelAgencyBack.Domain.Contracts;

namespace TravelAgencyBack.Api.Injects
{
    public static class AppServices
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddHttpClient();

            services.AddMediatR(cfg =>
                //cfg.RegisterServicesFromAssembly(typeof(Ping).Assembly)}
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
            );

            return services;
        }
    }
}
