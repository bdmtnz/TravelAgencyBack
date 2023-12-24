using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Net.NetworkInformation;
using System.Reflection;
using TravelAgencyBack.Domain.Contracts;

namespace TravelAgencyBack.Application.Injects
{
    public static class AppServices
    {
        //public static IServiceCollection AddAppServices(this IServiceCollection services)
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(AppServices).Assembly));

            //services.AddMediatR(cfg =>
            //    //cfg.RegisterServicesFromAssembly(typeof(Ping).Assembly)
            //    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
            //);

            //return services;
        }
    }
}
