using Microsoft.AspNetCore.Mvc;
using BuinessLogic.AdopterServices;
using ShiaApi.Models;

namespace ShiaApi.Controllers.AdopterControllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AdopterGetallController : ControllerBase
    {

        private readonly GetAllAdoptersService _getAllAdoptersService;

        public AdopterGetallController(DataContext context)
        {
            _getAllAdoptersService = new GetAllAdoptersService(context);
        }

        [HttpGet]
        public ActionResult<AdopterViewModel> Get()
        {
            var response = _getAllAdoptersService.GetAllAdopters();

            if (response.error)
            {
                ModelState.AddModelError("Get All Adopter", response.message);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            return Ok(response.adopters);
        }
    }
}