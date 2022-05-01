using Microsoft.AspNetCore.Mvc;
using BuinessLogic.EmployeeServices;
using ShiaApi.Models;

namespace ShiaApi.Controllers.EmployeeControllers{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeeGetallController : ControllerBase{

        private readonly GetAllEmployeesService _getAllEmployeesService;

        public EmployeeGetallController(DataContext context){
            _getAllEmployeesService = new GetAllEmployeesService(context);
        }

        [HttpGet]
        public ActionResult<EmployeeViewModel> Get(){
            var response = _getAllEmployeesService.GetAllEmployees();

            if(response.error){
                ModelState.AddModelError("Get All Employee", response.message);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            return Ok(response.employees);
        }
    }
}