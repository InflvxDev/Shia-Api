using Microsoft.AspNetCore.Mvc;
using BuinessLogic.AnimalServices;
using ShiaApi.Models;
using ShiaApi.Controllers.map;
using Entity;

namespace ShiaApi.Controllers.AnimalControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalUpdateController : ControllerBase
    {
        private readonly UpdateAnimalService _updateAnimalService;

        public AnimalUpdateController(DataContext context)
        {
            _updateAnimalService = new UpdateAnimalService(context);
        }

        [HttpPut]
        public ActionResult<AnimalViewModel> Put(AnimalInputModel animalInput)
        {
            Animal animal = new AnimalMap().AnimalMapper(animalInput);
            var response = _updateAnimalService.UpdateAnimal(animal);
            if (response.error)
            {
                ModelState.AddModelError("Update Animal", response.message);
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