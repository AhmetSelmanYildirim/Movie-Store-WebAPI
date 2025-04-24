using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Movie_Store_WebAPI.Application.MovieOperations.Commands.CreateMovie;
using Movie_Store_WebAPI.Application.MovieOperations.Commands.DeleteMovie;
using Movie_Store_WebAPI.Application.MovieOperations.Commands.UpdateMovie;
using Movie_Store_WebAPI.Application.MovieOperations.Queries;
using Movie_Store_WebAPI.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Movie_Store_WebAPI.Application.MovieOperations.Queries.GetMovieByIdQuery;

namespace Movie_Store_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public MovieController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            GetMoviesQuery query = new(_context, _mapper);
            var result = query.Handle();
                return Ok(result);
        }            

        [HttpGet("id")]
        public IActionResult GetMovieById(int id)
        {
            MovieDetailVM result;

            GetMovieByIdQuery query = new(_context, _mapper);
            GetMovieByIdQueryValidator validator = new();
            query.MovieId = id;
            validator.ValidateAndThrow(query);
            result = query.Handle();

            return Ok(result);

        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] CreateMovieVM newMovie)
        {
            CreateMovieCommand command = new(_context, _mapper);

            command.Model = newMovie;

            CreateMovieCommandValidator validator = new();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();

        }

        [HttpPut("id")]
        public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieVM updatedMovie)
        {
            UpdateMovieCommand command = new(_context);
            UpdateMovieCommandValidator validator = new();
            command.MovieId = id;
            command.Model = updatedMovie;
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpDelete("id")]
        public IActionResult DeleteMovie(int id)
        {
            DeleteMovieCommand command = new(_context);
            DeleteMovieCommandValidator validator = new();

            command.MovieId = id;
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

            
    }


    
}
