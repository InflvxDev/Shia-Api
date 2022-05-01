using BuinessLogic.EmployeeServices.Response;
using Data;

namespace BuinessLogic.EmployeeServices{
    public class GetOnlyEmployeeService {
        private readonly DataContext _dataContext;

        public GetOnlyEmployeeService(DataContext dataContext) {
            _dataContext = dataContext;
        }

        public EmployeeResponse GetOnlyEmployee(string identificationCard) {
            try {
                var employee = _dataContext.Employee.Find(identificationCard);
                if (employee == null || employee.State == "Deleted") {
                    return new EmployeeResponse("Employee not found");
                }
                return new EmployeeResponse("Employee getting successfully",employee);
            } catch (System.Exception) {
                return new EmployeeResponse("Error getting employee");
                throw;
            }
        }
    }
}