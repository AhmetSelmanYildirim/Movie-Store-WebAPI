using System;
using System.Linq;
using Movie_Store_WebAPI.DbOperations;

namespace Movie_Store_WebAPI.Application.ActorOperations.Commads.UpdateActor
{
    public class UpdateActorCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        public int ActorId { get; set; }
        public UpdateActorVM Model { get; set; }

        public UpdateActorCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UpdateActorCommand()
        {
        }

        public void Handle()
        {
            var actor = _dbContext.Actors.SingleOrDefault(x => x.ActorId == ActorId);

            if (actor == null)
            {
                throw new InvalidOperationException("Actor not found");
            }

            actor.Name = Model.Name != default ? Model.Name : actor.Name;
            actor.Surname = Model.Surname != default ? Model.Surname : actor.Surname;

            _dbContext.SaveChanges();
        }
    }
    public class UpdateActorVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }

}