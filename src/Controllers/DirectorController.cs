using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Movie_Store_WebAPI.Application.DirectorOperations.Commands.CreateDirector;
using Movie_Store_WebAPI.Application.DirectorOperations.Commands.DeleteDirector;
using Movie_Store_WebAPI.Application.DirectorOperations.Commands.UpdateDirector;
using Movie_Store_WebAPI.Application.DirectorOperations.Queries;
using Movie_Store_WebAPI.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            GetDirectorsQuery query = new(_dbContext, _mapper);
            var obj = query.Handle();
            return Ok(obj);
        }

        [HttpGet("id")]
        public IActionResult GetDirectorById(int id)
        {
            GetDirectorByIdQuery query = new( _dbContext, _mapper);
            query.DirectorId = id;
            GetDirectorByIdQueryValidator validator = new();
            validator.ValidateAndThrow(query);

            var obj = query.Handle();
            return Ok(obj);

        }

        [HttpPost]
        public IActionResult AddDirector([FromBody] CreateDirectorVM newDirector)
        {
            CreateDirectorCommand command = new(_dbContext, _mapper);
            command.Model = newDirector;

            CreateDirectorCommandValidator validator = new();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpPut("id")]
        public IActionResult UpdateDirector(int id, [FromBody] UpdateDirectorVM updatedDirector)
        {
            UpdateDirectorCommand command = new(_dbContext);
            UpdateDirectorCommandValidator validator = new();
            command.DirectorId = id;
            command.Model = updatedDirector;
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpDelete("id")]
        public IActionResult DeleteDirector(int id)
        {
            DeleteDirectorCommand command = new(_dbContext);
            DeleteDirectorCommandValidator validator = new();

            command.DirectorId = id;
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

    }
}
