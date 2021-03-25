using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Assign3.Models
{
    public class SeedDatabase
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            MovieDBContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<MovieDBContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Movies.Any())
            {
                context.Movies.AddRange(
                    new Movie
                    {
                        Title = "Tenet",
                        Category = "Action/Adventure",
                        Year = 2020,
                        Director = "Christopher Nolan",
                        Rating = "G",
                        Edited = "n/a",
                        Notes = "n/a",
                        Lent = "n/a"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
