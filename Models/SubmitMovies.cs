using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Assign3.Models
{

    public class SubmittedMovies
    {
        private static List<Movie> movies = new List<Movie>();

        public static IEnumerable<Movie> Movies => movies;

        
        public static IEnumerable<Movie> FilteredMovies => movies.FindAll(movie => movie.Title != "Independence Day");

        public static void AddMovie(Movie movie)
        {
            movies.Add(movie);
        }
    }
}

