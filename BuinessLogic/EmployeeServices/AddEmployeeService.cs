using BuinessLogic.EmployeeServices.Response;
using Data;
using Entity;

namespace BuinessLogic.EmployeeServices {
    public class AddEmployeeService {
        private readonly DataContext _dataContext;

        public AddEmployeeService(DataContext dataContext) {
            _dataContext = dataContext;
        }

        public EmployeeResponse AddEmployee(Employee employee){
            try
            {
                var employeeSearch = _dataContext.Employees.Find(employee.IdentificationCard);
                if(employeeSearch != null){
                    return new EmployeeResponse("Employee already exists");
                }
                
                employee.State = "Registered";
                _dataContext.Employees.Add(employee);
                _dataContext.SaveChanges();
                return new EmployeeResponse("Employee added or updated successfully",employee);

            }
            catch (System.Exception)
            {
                return new EmployeeResponse("Error adding employee");
                throw;
            }
        } 
    }
}