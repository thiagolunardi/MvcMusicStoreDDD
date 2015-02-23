using MvcMusicStore.Domain.Interfaces.Service;
using MvcMusicStore.Domain.Interfaces.Service.Common;
using MvcMusicStore.Domain.Services;
using MvcMusicStore.Domain.Services.Common;
using Ninject.Modules;

namespace MvcMusicStore.CrossCutting.InversionOfControl.Modules
{
    public class ServiceNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof (IService<>)).To(typeof (Service<>));

            Bind<IGenreService>().To<GenreService>();
            Bind<IArtistService>().To<ArtistService>();
            Bind<IAlbumService>().To<AlbumService>();
            Bind<ICartService>().To<CartService>();
            Bind<IOrderService>().To<OrderService>();
            Bind<IOrderDetailService>().To<OrderDetailService>();
        }
    }
}
