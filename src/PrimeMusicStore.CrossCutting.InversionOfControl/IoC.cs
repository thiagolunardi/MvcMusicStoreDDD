using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PrimeMusicStore.CrossCutting.InversionOfControl.Modules;
using PrimeMusicStore.Data.Context;

namespace PrimeMusicStore.CrossCutting.InversionOfControl
{
    public static class IoC
    {
        public static IServiceCollection AddPrimeStoreServices(this IServiceCollection services)          
        {
            services
                .RegisterAppServices()
                .RegisterInfrastructure()
                .RegisterRepositories()
                .RegisterDomainServices();

            return services;
        }

        public static void EnsureDatabaseCreated(this IApplicationBuilder app) 
        {
            var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using (var serviceScope = serviceScopeFactory.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<PrimeMusicStoreDbContext>();
                dbContext.Database.EnsureCreated();
            }
        }
    }
}
