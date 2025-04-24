using Movie_Store_WebAPI.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Movie_Store_WebAPI.Entities;

namespace Movie_Store_WebAPI.Application.MovieOperations.Queries
{
    public class GetMoviesQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;


        public GetMoviesQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<MoviesVM> Handle()
        {

            var movieList = _dbContext.Movies
                .Include(x => x.Director)
                .Include(a => a.MovieActors).ThenInclude(ma => ma.Actor)
                .ToList<Movie>();
            List<MoviesVM> vm = _mapper.Map<List<MoviesVM>>(movieList);
            return vm;
        }

        public class MoviesVM
        {
            public string Name { get; set; }
            public string Year { get; set; }
            public string Director { get; set; }
            public List<String> MovieActors { get; set; }
            public float Price { get; set; }
            public string Genre { get; set; }


        }


    }
}
