using MvcMusicStore.Application;
using MvcMusicStore.Application.Interfaces;
using Ninject.Modules;

namespace MvcMusicStore.CrossCutting.InversionOfControl.Modules
{
    public class ApplicationNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IGenreAppService>().To<GenreAppService>();
            Bind<IArtistAppService>().To<ArtistAppService>();
            Bind<IAlbumAppService>().To<AlbumAppService>();
            Bind<ICartAppService>().To<CartAppService>();
            Bind<IOrderAppService>().To<OrderAppService>();
            Bind<IOrderDetailAppService>().To<OrderDetailAppService>();
        }
    }
}
