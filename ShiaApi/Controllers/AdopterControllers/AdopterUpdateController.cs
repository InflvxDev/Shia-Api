using Microsoft.AspNetCore.Mvc;
using BuinessLogic.AdopterServices;
using ShiaApi.Models;
using ShiaApi.Controllers.map;
using Entity;

namespace ShiaApi.Controllers.AdopterControllers{
    [Route("api/[controller]")]
    [ApiController]

    public class AdopterUpdateController: ControllerBase{
        private readonly UpdateAdopterService _updateAdopterService;

        public AdopterUpdateController(DataContext context){
            _updateAdopterService = new UpdateAdopterService(context);
        }

        [HttpPut]
        public ActionResult<AdopterViewModel> Put(AdopterInputModel adopterInput){
            Adopter adopter = new AdopterMap().AdopterMapper(adopterInput);
            var response = _updateAdopterService.UpdateAdopter(adopter);
            if(response.error){
                ModelState.AddModelError("Update Adopter", response.message);
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