using AutoMapper;
using Movie_Store_WebAPI.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Store_WebAPI.Application.MovieOperations.Queries
{
    public class GetMovieByIdQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int MovieId { get; set; }

        public GetMovieByIdQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public MovieDetailVM Handle()
        {
            var movie = _dbContext.Movies.Where(movie => movie.MovieId == MovieId).SingleOrDefault();

            if(movie is null)
            {
                throw new InvalidOperationException("Movie not found");
            }

            MovieDetailVM vm = _mapper.Map<MovieDetailVM>(movie);

            return vm;

        }

        public class MovieDetailVM
        {
            public string Name { get; set; }
            public string Year { get; set; }
            public string Director { get; set; }
            public string Actors { get; set; }
            public float Price { get; set; }
            public string Genre { get; set; }
        }





    }
}
