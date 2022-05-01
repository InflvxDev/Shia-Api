using Microsoft.AspNetCore.Mvc;
using BuinessLogic.EmployeeServices;
using ShiaApi.Models;

namespace ShiaApi.Controllers.EmployeeControllers{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeeGetOnlyController: ControllerBase {
        private readonly GetOnlyEmployeeService _getOnlyEmployeeService;

        public EmployeeGetOnlyController(DataContext context){
            _getOnlyEmployeeService = new GetOnlyEmployeeService(context);
        }

        [HttpGet("{employeeID}")]
        public ActionResult<EmployeeViewModel> Get(string employeeID){
            var response = _getOnlyEmployeeService.GetOnlyEmployee(employeeID);

            if(response.error){
                ModelState.AddModelError("Get Only Employee", response.message);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            return Ok(response.employee);
        }
    }
}