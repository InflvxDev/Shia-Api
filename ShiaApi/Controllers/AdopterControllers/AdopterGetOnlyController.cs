using Microsoft.AspNetCore.Mvc;
using BuinessLogic.AdopterServices;
using ShiaApi.Models;


namespace ShiaApi.Controllers.AdopterControllers{
    [Route("api/[controller]")]
    [ApiController]

    public class AdopterGetOnlyController : ControllerBase{

        private readonly GetOnlyAdopterService _getOnlyAdopterService;

        public AdopterGetOnlyController(DataContext context){
            _getOnlyAdopterService = new GetOnlyAdopterService(context);
        }

        [HttpGet("{adopterID}")]
        public ActionResult<AdopterViewModel> Get(string adopterID){
            var response = _getOnlyAdopterService.GetOnlyAdopter(adopterID);

            if(response.error){
                ModelState.AddModelError("Get Only Adopter", response.message);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            return Ok(response.adopter);
        }
    }
}