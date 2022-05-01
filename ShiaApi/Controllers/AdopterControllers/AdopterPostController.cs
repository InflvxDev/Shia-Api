using Microsoft.AspNetCore.Mvc;
using BuinessLogic.AdopterServices;
using ShiaApi.Models;
using Entity;
using ShiaApi.Controllers.map;


namespace ShiaApi.Controllers.AdopterControllers{

    [Route("api/[controller]")]
    [ApiController]
    public class AdopterPostController : ControllerBase{

        private readonly AddAdopterService _addAdopterService;

        public AdopterPostController(DataContext context){
            _addAdopterService = new AddAdopterService(context);
        }

        [HttpPost]
        public ActionResult<AdopterViewModel> Post(AdopterInputModel adopterInput){
            Adopter adopter = new AdopterMap().AdopterMapper(adopterInput);
            var response = _addAdopterService.AddAdopter(adopter);

            if(response.error){
                ModelState.AddModelError("Add Adopter", response.message);
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