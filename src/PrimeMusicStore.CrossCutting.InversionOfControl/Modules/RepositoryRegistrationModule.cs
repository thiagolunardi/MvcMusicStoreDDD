using Microsoft.Extensions.DependencyInjection;
using PrimeMusicStore.Data.Repository.EntityFramework;
using PrimeMusicStore.Data.Repository.EntityFramework.Common;
using PrimeMusicStore.Domain.Interfaces.Repository;
using PrimeMusicStore.Domain.Interfaces.Repository.Common;

internal static class RepositoryRegistrationModule
{
    internal static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        services
            .AddScoped(typeof(IRepository<>), typeof(Repository<>))
            .AddScoped<IGenreRepository, GenreRepository>()
            .AddScoped<IArtistRepository, ArtistRepository>()
            .AddScoped<IAlbumRepository, AlbumRepository>()
            .AddScoped<ICartRepository, CartRepository>()
            .AddScoped<IOrderRepository, OrderRepository>()
            .AddScoped<IOrderDetailRepository, OrderDetailRepository>();

        return services;
    }
}
