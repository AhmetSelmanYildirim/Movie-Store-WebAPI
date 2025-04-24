using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Movie_Store_WebAPI.DbOperations;
using static Movie_Store_WebAPI.Application.MovieOperations.Queries.GetMoviesQuery;

namespace Movie_Store_WebAPI.Application.ActorOperations.Queries
{

    public class GetActorByIdQuery
    {

        private readonly IMapper _mapper;
        private readonly IMovieStoreDbContext _dbContext;
        public int ActorId { get; set; }

        public GetActorByIdQuery(IMapper mapper, IMovieStoreDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }


        public ActorDetailVM Handle(int actorId)
        {
            var actor = _dbContext.Actors
                .Include(a => a.MovieActors).ThenInclude(ma => ma.Movie).ThenInclude(d => d.Director)
                .Where(actor => actor.ActorId == actorId).SingleOrDefault();
            if (actor is null)
            {
                throw new InvalidOperationException("Movie not found");
            }

            ActorDetailVM vm = _mapper.Map<ActorDetailVM>(actor);

            return vm;
        }

    }

    public class ActorDetailVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Fullname
        {
            get => Name + " " + Surname;
        }
        public List<MoviesVM> movies { get; set; }

    }


}
