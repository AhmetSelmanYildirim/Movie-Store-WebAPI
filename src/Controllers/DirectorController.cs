using System;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Movie_Store_WebAPI.Application.DirectorOperations.Commands.CreateDirector;
using Movie_Store_WebAPI.Application.DirectorOperations.Commands.DeleteDirector;
using Movie_Store_WebAPI.Application.DirectorOperations.Commands.UpdateDirector;
using Movie_Store_WebAPI.Application.DirectorOperations.Queries;
using Movie_Store_WebAPI.DbOperations;

namespace Movie_Store_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class DirectorController : ControllerBase
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public DirectorController(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllDirectors()
        {
            try
            {
                GetDirectorsQuery query = new(_dbContext, _mapper);
                var obj = query.Handle();
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id")]
        public IActionResult GetDirectorById(int id)
        {
            try
            {
                GetDirectorByIdQuery query = new(_dbContext, _mapper)
                {
                    DirectorId = id
                };

                GetDirectorByIdQueryValidator validator = new();
                validator.ValidateAndThrow(query);

                var obj = query.Handle();
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddDirector([FromBody] CreateDirectorVM newDirector)
        {
            try
            {
                CreateDirectorCommand command = new(_dbContext, _mapper)
                {
                    Model = newDirector
                };

                CreateDirectorCommandValidator validator = new();
                validator.ValidateAndThrow(command);

                command.Handle();
                return Ok("Director added successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("id")]
        public IActionResult UpdateDirector(int id, [FromBody] UpdateDirectorVM updatedDirector)
        {
            try
            {
                UpdateDirectorCommand command = new(_dbContext)
                {
                    DirectorId = id,
                    Model = updatedDirector
                };

                UpdateDirectorCommandValidator validator = new();
                validator.ValidateAndThrow(command);

                command.Handle();
                return Ok("Director updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("id")]
        public IActionResult DeleteDirector(int id)
        {
            try
            {
                DeleteDirectorCommand command = new(_dbContext)
                {
                    DirectorId = id
                };

                DeleteDirectorCommandValidator validator = new();
                validator.ValidateAndThrow(command);

                command.Handle();
                return Ok("Director deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
