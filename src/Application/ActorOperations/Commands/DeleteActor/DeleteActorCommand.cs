using System;
using System.Linq;
using Movie_Store_WebAPI.DbOperations;

namespace Movie_Store_WebAPI.Application.ActorOperations.Commads.DeleteActor
{

    public class DeleteActorCommand
    {

        private readonly IMovieStoreDbContext _dbContext;
        public int ActorId { get; set; }
        public DeleteActorCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var actor = _dbContext.Actors.SingleOrDefault(a => a.ActorId == ActorId);
            if (actor == null)
            {
                throw new InvalidOperationException("Actor not found");
            }

            _dbContext.Actors.Remove(actor);
            _dbContext.SaveChanges();

        }

    }

}
