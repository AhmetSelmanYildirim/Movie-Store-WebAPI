using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Movie_Store_WebAPI.DbOperations;
using Movie_Store_WebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Store_WebAPI.Application.DirectorOperations.Queries
{
    public class GetDirectorByIdQuery
    {

        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public int DirectorId { get; set; }

        public GetDirectorByIdQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public DirectorDetailVM Handle()
        {
            var director = _dbContext.Directors.Include(d=> d.Movies).Where(x => x.ID == DirectorId).SingleOrDefault();

            if(director is null)
            {
                throw new InvalidOperationException("Director not found");
            }
            DirectorDetailVM vm = _mapper.Map<DirectorDetailVM>(director);
            return vm;
        } 
    }

    public class DirectorDetailVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
