using BuinessLogic.EmployeeServices;
using Microsoft.AspNetCore.Mvc;

namespace ShiaApi.Controllers.EmployeeControllers{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeeDeleteController: ControllerBase {
        private readonly DeleteEmployeeService _deleteEmployeeService;

        public EmployeeDeleteController(DataContext context){
            _deleteEmployeeService = new DeleteEmployeeService(context);
        }

        [HttpDelete("{employeeID}")]
        public ActionResult<string> Delete(string employeeID){
            var response = _deleteEmployeeService.DeleteEmployee(employeeID);

            if(response.error){
                ModelState.AddModelError("Delete Employee", response.message);
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