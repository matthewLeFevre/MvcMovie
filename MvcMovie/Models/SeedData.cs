using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "The Life of Jesus Christ Bible Videos",
                        ReleaseDate = DateTime.Parse("2012-2-12"),
                        Genre = "Religous",
                        Price = 9.99M,
                        Rating= "G"
                    },

                    new Movie
                    {
                        Title = "The Cokeville Miracle",
                        ReleaseDate = DateTime.Parse("2015-6-5"),
                        Genre = "Drama",
                        Price = 19.99M,
                        Rating = "PG-13"
                    },

                    new Movie
                    {
                        Title = "Return With Honor",
                        ReleaseDate = DateTime.Parse("2006-1-26"),
                        Genre = "Drama",
                        Price = 9.99M,
                        Rating = "PG-13"
                    },

                    new Movie
                    {
                        Title = "The Singles 2nd Ward",
                        ReleaseDate = DateTime.Parse("2007-12-11"),
                        Genre = "Comedy",
                        Price = 11.99M,
                        Rating = "PG"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}