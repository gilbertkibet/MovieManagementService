using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieManagement.Core.Repository;

namespace MovieManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       [HttpGet("get-actors")]

       public ActionResult Get()
        { 
           var actors=_unitOfWork.ActorRepository.GetAll();

            return Ok(actors);
        }

        [HttpGet("get-actor/movies")]
        public ActionResult GetActorsWithMovies()
        { 

           var actorsWithMovies= _unitOfWork.ActorRepository.GetActorsWithMovies();

            return Ok(actorsWithMovies);
        }
    }
}
