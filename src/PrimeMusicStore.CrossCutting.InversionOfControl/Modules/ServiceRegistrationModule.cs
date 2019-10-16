using Microsoft.Extensions.DependencyInjection;
using PrimeMusicStore.Domain.Interfaces.Service;
using PrimeMusicStore.Domain.Interfaces.Service.Common;
using PrimeMusicStore.Domain.Services;
using PrimeMusicStore.Domain.Services.Common;

internal static class DomainRegistrationModule
{
    internal static IServiceCollection RegisterDomainServices(this IServiceCollection services)
    {
        services
            .AddScoped(typeof(IService<>), typeof(Service<>))

            .AddScoped<IGenreService, GenreService>()
            .AddScoped<IArtistService, ArtistService>()
            .AddScoped<IAlbumService, AlbumService>()
            .AddScoped<ICartService, CartService>()
            .AddScoped<IOrderService, OrderService>()
            .AddScoped<IOrderDetailService, OrderDetailService>();

        return services;
    }
}
