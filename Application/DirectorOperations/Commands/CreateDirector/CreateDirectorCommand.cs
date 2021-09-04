using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Movie_Store_WebAPI.DbOperations;
using Movie_Store_WebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Store_WebAPI.Application.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommand
    {
        public CreateDirectorVM Model { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateDirectorCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var director = _dbContext.Directors
                .SingleOrDefault(x => x.Name == Model.Name);

            if(director is not null)
            {
                throw new InvalidOperationException("Director already exist");
            }

            director = _mapper.Map<Director>(Model);

            _dbContext.Directors.Add(director);
            _dbContext.SaveChanges();
        }



    }

    public class CreateDirectorVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
