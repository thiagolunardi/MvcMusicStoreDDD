using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PrimeMusicStore.Data.Context;
using PrimeMusicStore.Data.Context.Interfaces;

namespace PrimeMusicStore.CrossCutting.InversionOfControl.Modules
{
    internal static class InfrastructureRegistrationModule
    {
        internal static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
        {
            services
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddDbContext<PrimeMusicStoreDbContext>();

            return services;
        }
    }
}
