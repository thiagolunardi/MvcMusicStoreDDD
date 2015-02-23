using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Application.Interfaces;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        private readonly IGenreAppService _genreAppService;
        private readonly IAlbumAppService _albumAppService;

        public StoreController(IGenreAppService genreAppService, IAlbumAppService albumAppService)
        {
            _genreAppService = genreAppService;
            _albumAppService = albumAppService;
        }

        //
        // GET: /Store/

        public ActionResult Index()
        {
            var genres = _genreAppService.All(@readonly: true);

            return View(genres);
        }

        //
        // GET: /Store/Browse?genre=Disco

        public ActionResult Browse(string genre)
        {
            // Retrieve Genre and its Associated Albums from database
            var genreModel = _genreAppService.GetWithAlbums(genre);

            return View(genreModel);
        }

        //
        // GET: /Store/Details/5

        public ActionResult Details(int id)
        {
            var album = _albumAppService.Get(id, @readonly: true);

            return View(album);
        }

        //
        // GET: /Store/GenreMenu

        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            var genres = _genreAppService.All(@readonly: true);

            return PartialView(genres);
        }

    }
}