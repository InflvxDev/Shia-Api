using BuinessLogic.AdopterServices;
using Microsoft.AspNetCore.Mvc;

namespace ShiaApi.Controllers.AdopterControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdopterDeleteController : ControllerBase
    {
        private readonly DeleteAdopterService _deleteAdopterService;

        public AdopterDeleteController(DataContext context)
        {
            _deleteAdopterService = new DeleteAdopterService(context);
        }

        [HttpDelete("{adopterID}")]
        public ActionResult<string> Delete(string adopterID)
        {
            var response = _deleteAdopterService.DeleteAdopter(adopterID);

            if (response.error)
            {
                ModelState.AddModelError("Delete Adopter", response.message);
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