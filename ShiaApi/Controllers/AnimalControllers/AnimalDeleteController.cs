using BuinessLogic.AnimalServices;
using Microsoft.AspNetCore.Mvc;

namespace ShiaApi.Controllers.AnimalControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalDeleteController : ControllerBase
    {
        private readonly DeleteAnimalService _deleteAnimalService;

        public AnimalDeleteController(DataContext context)
        {
            _deleteAnimalService = new DeleteAnimalService(context);
        }

        [HttpDelete("{animalID}")]
        public ActionResult<string> Delete(string animalID)
        {
            var response = _deleteAnimalService.DeleteAnimal(animalID);

            if (response.error)
            {
                ModelState.AddModelError("Delete Animal", response.message);
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