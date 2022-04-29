using BuinessLogic.EmployeeServices.Response;
using Data;

namespace BuinessLogic.EmployeeServices
{
    public class DeleteEmployeeService
    {
        private readonly DataContext _dataContext;

        public DeleteEmployeeService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public EmployeeResponse DeleteEmployee(string identificationCard)
        {
            try
            {
                var employee = _dataContext.Employee.Find(identificationCard);
                if (employee == null)
                {
                    return new EmployeeResponse("Employee not found");
                }
                
                employee.State = "Deleted";
                _dataContext.Employee.Update(employee);
                _dataContext.SaveChanges();
                return new EmployeeResponse("Employee deleted successfully", employee);
            }
            catch (System.Exception)
            {
                return new EmployeeResponse("Error deleting employee");
                throw;
            }
        }
    }
}