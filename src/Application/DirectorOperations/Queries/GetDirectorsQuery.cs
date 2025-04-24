using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Movie_Store_WebAPI.DbOperations;
using Movie_Store_WebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Movie_Store_WebAPI.Application.MovieOperations.Queries.GetMoviesQuery;

namespace Movie_Store_WebAPI.Application.DirectorOperations.Queries
{
    public class GetDirectorsQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDirectorsQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<DirectorsVM> Handle()
        {
            var directors = _dbContext.Directors
                .Include(d => d.Movies)
                .OrderBy(x => x.ID).ToList<Director>();
            List<DirectorsVM> returnObj = _mapper.Map<List<DirectorsVM>>(directors);


            return returnObj;
        }

    }

    public class DirectorsVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<MoviesVM> Movies { get; set; }
    }
}
