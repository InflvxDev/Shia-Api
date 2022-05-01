using Microsoft.AspNetCore.Mvc;
using BuinessLogic.EmployeeServices;
using ShiaApi.Models;
using Entity;
using ShiaApi.Controllers.map;

namespace ShiaApi.Controllers.EmployeeControllers{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeePostController : ControllerBase{

        private readonly AddEmployeeService _addEmployeeService;

        public EmployeePostController(DataContext context){
            _addEmployeeService = new AddEmployeeService(context);
        }

        [HttpPost]
        public ActionResult<EmployeeViewModel> Post(EmployeeInputModel employeeInputModel){
            Employee employee = new EmployeeMap().EmployeeMapper(employeeInputModel);
            var response = _addEmployeeService.AddEmployee(employee);

            if(response.error){
                ModelState.AddModelError("Add Employee", response.message);
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