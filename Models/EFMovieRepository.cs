using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assign3.Models
{
    // this creates all the update delete and save features
    public class EFMovieRepository : iMovieRepository
    {
        private MovieDBContext _context;

        public EFMovieRepository(MovieDBContext context)
        {
            _context = context;
        }
        public IQueryable<Movie> Movies => (_context.Movies);

        public void AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void UpdateMovie(Movie movie)
        {
            Movie objmovie = _context.Movies.Where(m => m.MovieID == movie.MovieID).FirstOrDefault();

            objmovie.Title = movie.Title;
            objmovie.Rating = movie.Rating;
            objmovie.Year = movie.Year;
            objmovie.Edited = movie.Edited;
            objmovie.Director = movie.Director;
            objmovie.Lent = movie.Lent;
            objmovie.Notes = movie.Notes;

            _context.SaveChanges();
        }


        public void DeleteMovie(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
    }
}
