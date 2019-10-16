using Microsoft.Extensions.DependencyInjection;
using PrimeMusicStore.Application;
using PrimeMusicStore.Application.Interfaces;

namespace PrimeMusicStore.CrossCutting.InversionOfControl.Modules
{
    internal static class ApplicationRegistrationModule
    {
        internal static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            services
                .AddScoped<IGenreAppService, GenreAppService>()
                .AddScoped<IArtistAppService, ArtistAppService>()
                .AddScoped<IAlbumAppService, AlbumAppService>()
                .AddScoped<ICartAppService, CartAppService>()
                .AddScoped<IOrderAppService, OrderAppService>()
                .AddScoped<IOrderDetailAppService, OrderDetailAppService>();

            return services;
        }
    }
}
