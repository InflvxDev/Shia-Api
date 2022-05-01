using Microsoft.AspNetCore.Mvc;
using BuinessLogic.AnimalServices;
using ShiaApi.Models;

namespace ShiaApi.Controllers.AnimalControllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AnimalGetallController : ControllerBase
    {

        private readonly GetAllAnimalsService _getAllAnimalsService;

        public AnimalGetallController(DataContext context)
        {
            _getAllAnimalsService = new GetAllAnimalsService(context);
        }

        [HttpGet]
        public ActionResult<AnimalViewModel> Get()
        {
            var response = _getAllAnimalsService.GetAllAnimals();

            if (response.error)
            {
                ModelState.AddModelError("Get All Animal", response.message);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            return Ok(response.animals);
        }
    }
}