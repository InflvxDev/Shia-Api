using Microsoft.AspNetCore.Mvc;
using BuinessLogic.AnimalServices;
using ShiaApi.Models;
using Entity;
using ShiaApi.Controllers.map;

namespace ShiaApi.Controllers.AnimalControllers{

    [Route("api/[controller]")]
    [ApiController]
    public class AnimalPostController : ControllerBase{

        private readonly AddAnimalService _addAnimalService;

        public AnimalPostController(DataContext context){
            _addAnimalService = new AddAnimalService(context);
        }

        [HttpPost]
        public ActionResult<AnimalViewModel> Post(AnimalInputModel animalInputModel){
            Animal animal = new AnimalMap().AnimalMapper(animalInputModel);
            var response = _addAnimalService.AddAnimal(animal);

            if(response.error){
                ModelState.AddModelError("Add Animal", response.message);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            return Ok(response.message);
        }
    }
}