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
            /* Movie */
            CreateMap<MoviesVM, Movie>();
            CreateMap<Movie, MoviesVM>()
                .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.Fullname))
                .ForMember(dto => dto.MovieActors, opt => opt.MapFrom(x => x.MovieActors.Select(y => y.Actor.Fullname).ToList()));

            CreateMap<MovieDetailVM, Movie>();
            CreateMap<Movie, MovieDetailVM>().ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.Fullname));

            CreateMap<CreateMovieVM, Movie>();

            /* Director */

            CreateMap<Director, DirectorsVM>().ForMember(dest => dest.Movies, opt =>
                opt.MapFrom(src => src.Movies.Select(x =>
                    new Movie() { Name = x.Name, }
                ))
            );

            CreateMap<Director, DirectorDetailVM>().ForMember(dest => dest.Movies, opt =>
                opt.MapFrom(src => src.Movies.Select(x =>
                     new Movie() { Name = x.Name, }
                ))
            );

            CreateMap<CreateDirectorVM, Director>();

            /* Actor */


        }
    }
}
