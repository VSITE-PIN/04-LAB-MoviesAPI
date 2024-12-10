using Microsoft.VisualBasic;
using MoviesAPI.Data;
using System;

namespace MoviesAPI.Services
{
    public class MoviesService
    {
        private readonly AppDbContext _context;
        public MoviesService(AppDbContext context)
        {
            _context = context;
        }

        public object AppDbcontext { get; private set; }

        public void AddMovie(Movie movie)
        {
            if (movie is null)
            {
                throw new ArgumentNullException(nameof(movie));
            }

            var newMovie = new Movie()
            {
                Title = movie.Title,
                Year = movie.Year,
                Id = movie.Id,
                Genre = movie.Genre,
                MovieAdded = movie.MovieAdded,
                MovieDeleted = movie.MovieDeleted,
            };
             _context.Movies.Add(newMovie);
             _context.SaveChanges();
        }
    }
}
