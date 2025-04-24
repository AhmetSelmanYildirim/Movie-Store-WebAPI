using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    }
}