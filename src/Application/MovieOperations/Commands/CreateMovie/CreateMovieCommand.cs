using AutoMapper;
using Movie_Store_WebAPI.DbOperations;
using Movie_Store_WebAPI.Entities;
using System;
using System.Linq;

namespace Movie_Store_WebAPI.Application.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommand
    {
        public CreateMovieVM Model { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateMovieCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var movie = _dbContext.Movies.SingleOrDefault(x => x.Name == Model.Name);

            if (movie is not null)
            {
                throw new InvalidOperationException("Movie already exist");
            }

            movie = _mapper.Map<Movie>(Model);
            if (Model.Director > 0)
            {
                movie.DirectorId = Model.Director;
            }
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
        }

    }

    public class CreateMovieVM
    {
        public string Name { get; set; }
        public DateTime Year { get; set; }
        public int Director { get; set; }
        public string Actors { get; set; }
        public float Price { get; set; }
        public string Genre { get; set; }

    }
}
