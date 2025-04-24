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
            GetActorsQuery query = new(_dbContext, _mapper);
            var obj = query.Handle();
            return Ok(obj);
        }

        [HttpGet("id")]
        public IActionResult GetActorById(int id)
        {
            ActorDetailVM result;

            GetActorByIdQuery query = new(_mapper, _dbContext);
            GetActorByIdQueryValidator validator = new();
            query.ActorId = id;
            validator.ValidateAndThrow(query);
            result = query.Handle(id);

            return Ok(result);

        }

        [HttpPost]
        public IActionResult CreateActor([FromBody] CreateActorVM newActor)
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

        [HttpPut("id")]
        public IActionResult UpdateActor(int id, [FromBody] UpdateActorVM updateActorObj)
        {
            UpdateActorCommand command = new(_dbContext);
            UpdateActorCommandValidator validator = new();
            command.ActorId = id;
            command.Model = updateActorObj;
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok("Actor updated successfully");
        }

        [HttpDelete("id")]
        public IActionResult DeleteActor(int id)
        {
            DeleteActorCommand command = new(_dbContext);
            DeleteActorCommandValidator validator = new();
            command.ActorId = id;
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok("Actor deleted successfully");
        }
    }
}