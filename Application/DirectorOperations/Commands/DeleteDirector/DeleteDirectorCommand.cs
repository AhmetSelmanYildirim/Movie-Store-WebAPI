using Movie_Store_WebAPI.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Store_WebAPI.Application.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        public int DirectorId { get; set; }

        public DeleteDirectorCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var director = _dbContext.Directors.SingleOrDefault(x => x.ID == DirectorId);
        
            if(director is null)
            {
                throw new InvalidOperationException("Director not found");
            }

            _dbContext.Directors.Remove(director);
            _dbContext.SaveChanges();

        }

    }
}
