using System;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Movie_Store_WebAPI.Application.MovieOperations.Commands.CreateMovie;
using Movie_Store_WebAPI.Application.MovieOperations.Commands.DeleteMovie;
using Movie_Store_WebAPI.Application.MovieOperations.Commands.UpdateMovie;
using Movie_Store_WebAPI.Application.MovieOperations.Queries;
using Movie_Store_WebAPI.DbOperations;
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
            try
            {
                GetMoviesQuery query = new(_context, _mapper);
                var result = query.Handle();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id")]
        public IActionResult GetMovieById(int id)
        {
            try
            {
                GetMovieByIdQuery query = new(_context, _mapper)
                {
                    MovieId = id
                };

                GetMovieByIdQueryValidator validator = new();
                validator.ValidateAndThrow(query);

                MovieDetailVM result = query.Handle();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] CreateMovieVM newMovie)
        {
            try
            {
                CreateMovieCommand command = new(_context, _mapper)
                {
                    Model = newMovie
                };

                CreateMovieCommandValidator validator = new();
                validator.ValidateAndThrow(command);

                command.Handle();
                return Ok("Movie created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("id")]
        public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieVM updatedMovie)
        {
            try
            {
                UpdateMovieCommand command = new(_context)
                {
                    MovieId = id,
                    Model = updatedMovie
                };

                UpdateMovieCommandValidator validator = new();
                validator.ValidateAndThrow(command);

                command.Handle();
                return Ok("Movie updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("id")]
        public IActionResult DeleteMovie(int id)
        {
            try
            {
                DeleteMovieCommand command = new(_context)
                {
                    MovieId = id
                };

                DeleteMovieCommandValidator validator = new();
                validator.ValidateAndThrow(command);

                command.Handle();
                return Ok("Movie deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
