using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Movie_Store_WebAPI.DbOperations;
using Movie_Store_WebAPI.Entities;

namespace Movie_Store_WebAPI.Application.ActorOperations.Commads.CreateActor
{

    public class CreateActorCommand
    {
        public CreateActorVM Model { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateActorCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var actor = _dbContext.Actors.SingleOrDefault(x => x.Name == Model.Name && x.Surname == Model.Surname);

            if (actor is not null)
            {
                throw new InvalidOperationException("Actor already exist");
            }

            actor = _mapper.Map<Actor>(Model);

            if (Model.MovieIds != null && Model.MovieIds.Any())
            {
                actor.MovieActors = Model.MovieIds
                    .Select(movieId => new MovieActor
                    {
                        MovieId = movieId,
                        Actor = actor
                    }).ToList();
            }

            _dbContext.Actors.Add(actor);
            _dbContext.SaveChanges();
        }
    }

    public class CreateActorVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<int> MovieIds { get; set; }
    }

}
