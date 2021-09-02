using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Movie_Store_WebAPI.Application.DirectorOperations.Commands.CreateDirector;
using Movie_Store_WebAPI.Application.DirectorOperations.Queries;
using Movie_Store_WebAPI.Application.MovieOperations.Commands.CreateMovie;
using Movie_Store_WebAPI.Application.MovieOperations.Queries;
using Movie_Store_WebAPI.Entities;
using static Movie_Store_WebAPI.Application.MovieOperations.Queries.GetMovieByIdQuery;
using static Movie_Store_WebAPI.Application.MovieOperations.Queries.GetMoviesQuery;

namespace Movie_Store_WebAPI.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MoviesVM, Movie>();
            CreateMap<Movie, MoviesVM>().ForMember(dest=> dest.Director, opt => opt.MapFrom(src => src.Director.Fullname));
            CreateMap<MovieDetailVM, Movie>();
            CreateMap<Movie, MovieDetailVM>().ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.Fullname));
            CreateMap<CreateMovieVM, Movie>();

            CreateMap<Director, DirectorsVM>();
            CreateMap<Director, DirectorDetailVM>();
            CreateMap<CreateDirectorVM, Director>();
            

        }
    }
}
