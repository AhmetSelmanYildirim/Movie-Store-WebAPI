using System;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Movie_Store_WebAPI.Application.ActorOperations.Commads.CreateActor;
using Movie_Store_WebAPI.Application.ActorOperations.Commads.DeleteActor;
using Movie_Store_WebAPI.Application.ActorOperations.Commads.UpdateActor;
using Movie_Store_WebAPI.Application.ActorOperations.Commands.CreateActor;
using Movie_Store_WebAPI.Application.ActorOperations.Commands.DeleteActor;
using Movie_Store_WebAPI.Application.ActorOperations.Commands.UpdateActor;
using Movie_Store_WebAPI.Application.ActorOperations.Queries;
using Movie_Store_WebAPI.DbOperations;

namespace Movie_Store_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class ActorController : ControllerBase
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public ActorController(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllActors()
        {
            try
            {
                GetActorsQuery query = new(_dbContext, _mapper);
                var obj = query.Handle();
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id")]
        public IActionResult GetActorById(int id)
        {
            try
            {
                GetActorByIdQuery query = new(_mapper, _dbContext)
                {
                    ActorId = id
                };

                GetActorByIdQueryValidator validator = new();
                validator.ValidateAndThrow(query);

                var result = query.Handle(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateActor([FromBody] CreateActorVM newActor)
        {
            try
            {
                var command = new CreateActorCommand(_dbContext, _mapper)
                {
                    Model = newActor
                };

                var validator = new CreateActorCommandValidator();
                validator.ValidateAndThrow(command);

                command.Handle();
                return Ok("Actor created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("id")]
        public IActionResult UpdateActor(int id, [FromBody] UpdateActorVM updateActorObj)
        {
            try
            {
                UpdateActorCommand command = new(_dbContext)
                {
                    ActorId = id,
                    Model = updateActorObj
                };

                UpdateActorCommandValidator validator = new();
                validator.ValidateAndThrow(command);

                command.Handle();
                return Ok("Actor updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("id")]
        public IActionResult DeleteActor(int id)
        {
            try
            {
                DeleteActorCommand command = new(_dbContext)
                {
                    ActorId = id
                };

                DeleteActorCommandValidator validator = new();
                validator.ValidateAndThrow(command);

                command.Handle();
                return Ok("Actor deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
