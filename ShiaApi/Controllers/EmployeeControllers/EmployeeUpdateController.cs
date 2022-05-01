using Microsoft.AspNetCore.Mvc;
using BuinessLogic.EmployeeServices;
using ShiaApi.Models;
using ShiaApi.Controllers.map;
using Entity;


namespace ShiaApi.Controllers.EmployeeControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeUpdateController : ControllerBase
    {
        private readonly UpdateEmployeeService _updateEmployeeService;

        public EmployeeUpdateController(DataContext context)
        {
            _updateEmployeeService = new UpdateEmployeeService(context);
        }

        [HttpPut]
        public ActionResult<EmployeeViewModel> Put(EmployeeInputModel employeeInput)
        {
            Employee employee = new EmployeeMap().EmployeeMapper(employeeInput);
            var response = _updateEmployeeService.UpdateEmployee(employee);
            if (response.error)
            {
                ModelState.AddModelError("Update Employee", response.message);
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