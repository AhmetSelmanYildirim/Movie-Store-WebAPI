using Movie_Store_WebAPI.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Store_WebAPI.Application.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        public UpdateDirectorVM Model { get; set; }
        public int DirectorId { get; set; }

        public UpdateDirectorCommand(IMovieStoreDbContext dbContext)
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

            director.Name = Model.Name != default ? Model.Name : director.Name;
            director.Surname = Model.Surname != default ? Model.Surname : director.Surname;

            _dbContext.SaveChanges();

        }

    }

    public class UpdateDirectorVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
