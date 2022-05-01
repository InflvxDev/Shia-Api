using Microsoft.AspNetCore.Mvc;
using BuinessLogic.AnimalServices;
using ShiaApi.Models;

namespace ShiaApi.Controllers.AnimalControllers{
    [Route("api/[controller]")]
    [ApiController]

    public class AnimalGetOnlyController : ControllerBase{

        private readonly GetOnlyAnimalService _getOnlyAnimalService;

        public AnimalGetOnlyController(DataContext context){
            _getOnlyAnimalService = new GetOnlyAnimalService(context);
        }

        [HttpGet("{animalID}")]
        public ActionResult<AnimalViewModel> Get(string animalID){
            var response = _getOnlyAnimalService.GetOnlyAnimal(animalID);

            if(response.error){
                ModelState.AddModelError("Get Only Animal", response.message);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            return Ok(response.animal);
        }
    }
}