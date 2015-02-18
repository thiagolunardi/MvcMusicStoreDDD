using System.Linq;
using System.Web.Mvc;
using MvcMusicStore.Application.Interfaces;
using MvcMusicStore.Domain.Entities;

namespace MvcMusicStore.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class StoreManagerController : Controller
    {
        private readonly IAlbumAppService _albumAppService;
        private readonly IArtistAppService _artistAppService;
        private readonly IGenreAppService _genreAppService;

        public StoreManagerController(IAlbumAppService albumAppService, IArtistAppService artistAppService, IGenreAppService genreAppService)
        {
            _albumAppService = albumAppService;
            _artistAppService = artistAppService;
            _genreAppService = genreAppService;
        }

        //
        // GET: /StoreManager/

        public ViewResult Index()
        {
            var albums = _albumAppService.All();
            return View(albums.ToList());
        }

        //
        // GET: /StoreManager/Details/5

        public ViewResult Details(int id)
        {
            var album = _albumAppService.Get(id, @readonly: true);
            return View(album);
        }

        //
        // GET: /StoreManager/Create

        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(_genreAppService.All(@readonly: true), "GenreId", "Name");
            ViewBag.ArtistId = new SelectList(_artistAppService.All(@readonly: true), "ArtistId", "Name");
            return View();
        } 

        //
        // POST: /StoreManager/Create

        [HttpPost]
        public ActionResult Create(Album album)
        {
            if (ModelState.IsValid)
            {
                var validationResult = _albumAppService.Create(album);
                
                if (validationResult.IsValid) 
                    return RedirectToAction("Index");
                
                foreach (var error in validationResult.Errors)
                    ModelState.AddModelError("", error.Message);
            }

            ViewBag.GenreId = new SelectList(_genreAppService.All(@readonly: true), "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(_artistAppService.All(@readonly: true), "ArtistId", "Name", album.ArtistId);
            return View(album);
        }
        
        //
        // GET: /StoreManager/Edit/5
 
        public ActionResult Edit(int id)
        {
            var album = _albumAppService.Get(id, @readonly: true);
            ViewBag.GenreId = new SelectList(_genreAppService.All(@readonly: true), "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(_artistAppService.All(@readonly: true), "ArtistId", "Name", album.ArtistId);
            return View(album);
        }

        //
        // POST: /StoreManager/Edit/5

        [HttpPost]
        public ActionResult Edit(Album album)
        {
            if (ModelState.IsValid)
            {
                var validationResult = _albumAppService.Update(album);

                if (validationResult.IsValid)
                    return RedirectToAction("Index");

                foreach (var error in validationResult.Errors)
                    ModelState.AddModelError("", error.Message);

                return View(album);
            }
            ViewBag.GenreId = new SelectList(_genreAppService.All(@readonly: true), "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(_artistAppService.All(@readonly: true), "ArtistId", "Name", album.ArtistId);
            return View(album);
        }

        //
        // GET: /StoreManager/Delete/5
 
        public ActionResult Delete(int id)
        {
            var album = _albumAppService.Get(id, @readonly: true);
            return View(album);
        }

        //
        // POST: /StoreManager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            var album = _albumAppService.Get(id);
            _albumAppService.Remove(album);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _albumAppService.Dispose();
            _artistAppService.Dispose();
            _genreAppService.Dispose();

            base.Dispose(disposing);
        }
    }
}