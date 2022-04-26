using BuinessLogic.EmployeeServices.Response;
using Data;

namespace BuinessLogic.EmployeeServices {
    public class GetAllEmployeesService {
        private readonly DataContext _dataContext;

        public GetAllEmployeesService(DataContext dataContext) {
            _dataContext = dataContext;
        }

        public EmployeeResponse GetAllEmployees() {
            try {
                var employees = _dataContext.Employees.ToList();
                return new EmployeeResponse(employees);
            } catch (System.Exception) {
                return new EmployeeResponse("Error getting employees");
                throw;
            }
        }
    }
}