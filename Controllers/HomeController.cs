using Assign3.Models;
using Assign3.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assign3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private iMovieRepository _repository;

        public HomeController(ILogger<HomeController> logger, iMovieRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult BaconSale()
        {
            return View();
        }

        public IActionResult MovieList()
        {
            return View(new MovieListViewModel
            {
                Movies = _repository.Movies
            }
            );
        }

        [HttpPost]
        public IActionResult MovieForm(Movie movie)
        {
            Debug.WriteLine(movie.Category);
            if (ModelState.IsValid)
            {
                _repository.AddMovie(movie);
            }
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditMovie(Movie movie)
        {
            Debug.Print("yo");
            int movieid = movie.MovieID;
            if (movieid == null)
            {
                return View("Index");
            }

            _repository.UpdateMovie(movie);

            return View("MovieList", new MovieListViewModel
            {
                Movies = _repository.Movies
            }
            );
        }

        [HttpGet]
        public IActionResult EditMovie(string movieid)
        {
            if (movieid == null)
            {
                return View("Error");
            }
            int theid = int.Parse(movieid);
            Movie m = _repository.Movies
                           .Where(m => m.MovieID == theid)
                           .FirstOrDefault<Movie>();

            return View(new EditMovieViewModel { Movie = m });
        }

        [HttpPost]
        public IActionResult DeleteMovie(string movieid)
        {
            if (movieid == null)
            {
                return View("Error");
            }

            int theid = int.Parse(movieid);
            Movie movie = _repository.Movies
                           .Where(m => m.MovieID == theid)
                           .FirstOrDefault<Movie>();

            _repository.DeleteMovie(movie);

            return View("MovieList", new MovieListViewModel
            {
                Movies = _repository.Movies
            }
            );
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
