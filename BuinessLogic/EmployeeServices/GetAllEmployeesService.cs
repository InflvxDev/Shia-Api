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
                var employees = _dataContext.Employee.Where(e => e.State == "Registered").ToList();
                return new EmployeeResponse(employees);
            } catch (System.Exception) {
                return new EmployeeResponse("Error getting employees");
                throw;
            }
        }
    }
}