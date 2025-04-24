using Movie_Store_WebAPI.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Store_WebAPI.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        public UpdateMovieVM Model { get; set; }
        public int MovieId { get; set; }

        public UpdateMovieCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var movie = _dbContext.Movies.SingleOrDefault(x => x.MovieId == MovieId);

            if(movie is null)
            {
                throw new InvalidOperationException("Movie not found");
            }

            movie.Name = Model.Name != default ? Model.Name : movie.Name;
            movie.Year = Model.Year != default ? Model.Year : movie.Year;
            movie.Price = Model.Price != default ? Model.Price : movie.Price;
            movie.Genre = Model.Genre != default ? Model.Genre : movie.Genre;

            _dbContext.SaveChanges();


        }



    }

    public class UpdateMovieVM
    {
        public string Name { get; set; }
        public DateTime Year { get; set; }
        public float Price { get; set; }
        public string Genre { get; set; }
    }
}
