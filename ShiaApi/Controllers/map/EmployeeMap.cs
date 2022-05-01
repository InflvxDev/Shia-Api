using Entity;
using ShiaApi.Models;

namespace ShiaApi.Controllers.map{
    public class EmployeeMap{
        public Employee EmployeeMapper(EmployeeInputModel employeeInput){
            var employee = new Employee{
                
                IdentificationCard = employeeInput.IdentificationCard,
                Name = employeeInput.Name,
                LastName = employeeInput.LastName,
                Email = employeeInput.Email,
                Phone = employeeInput.Phone,
                Address = employeeInput.Address,
                Job = employeeInput.Job,
                State = employeeInput.State
            };
            return employee;
        }
    }
}