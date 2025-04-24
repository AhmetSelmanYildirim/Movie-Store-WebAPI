using Movie_Store_WebAPI.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Store_WebAPI.Application.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        public int MovieId { get; set; }

        public DeleteMovieCommand(IMovieStoreDbContext dbContext)
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

            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();

        }

    }
}
