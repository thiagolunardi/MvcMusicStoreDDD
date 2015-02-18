using System.Web.Mvc;
using MvcMusicStore.Application.Interfaces;

namespace MvcMusicStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAlbumAppService _albumAppService;
        public HomeController(IAlbumAppService albumAppService)
        {
            _albumAppService = albumAppService;
        }

        public ActionResult Index()
        {
            // Get most popular albums
            var albums = _albumAppService.GetTopSellingAlbums(5);

            return View(albums);
        }
    }
}