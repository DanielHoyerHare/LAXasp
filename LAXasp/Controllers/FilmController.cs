using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LAXasp.Models;

namespace LAXasp.Controllers
{
    public class FilmController : Controller
    {
        private FilmDBContext db = new FilmDBContext();

        // GET: Film
        public ActionResult Index(string movieGenre,string searchString)
        {
            var GenreList = new List<string>();
            var GenreQuery = from d in db.Film orderby d.Genre select d.Genre;
            GenreList.AddRange(GenreQuery.Distinct());
            ViewBag.movieGenre = new SelectList(GenreList);

            var movies = from m in db.Film select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Titel.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }

            return View(movies);
        }

        // GET: Film/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Film.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
