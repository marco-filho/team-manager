using Microsoft.Extensions.DependencyInjection;
using TeamManager.Domain.Interfaces;
using TeamManager.Infrastructure.Data.Repositories;
using TeamManager.Interfaces;
using TeamManager.Services;

namespace TeamManager.Infrastructure.ExtensionMethods
{
    public static class CommonInjectDependence
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IJogadorViewModelService, JogadorViewModelService>();
            services.AddTransient<ITimeViewModelService, TimeViewModelService>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IJogadorRepository, JogadorRepository>();
            services.AddTransient<ITimeRepository, TimeRepository>();
            return services;
        }
    }
}
