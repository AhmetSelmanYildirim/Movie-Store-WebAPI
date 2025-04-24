using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Movie_Store_WebAPI.DbOperations;
using Movie_Store_WebAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Movie_Store_WebAPI.Application.ActorOperations.Queries
{

    public class GetActorsQuery
    {

        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetActorsQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<ActorsVM> Handle()
        {
            var actors = _dbContext.Actors
                .OrderBy(x => x.ActorId)
                .Include(a => a.MovieActors).ThenInclude(ma => ma.Movie)
                .ToList<Actor>();
            List<ActorsVM> vm = _mapper.Map<List<ActorsVM>>(actors);

            return vm;
        }
    }

    public class ActorsVM
    {
        public string Fullname { get; set; }
        public List<string> Movies { get; set; }
    }


}
