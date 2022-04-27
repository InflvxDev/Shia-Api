using Entity;

namespace BuinessLogic.EmployeeServices.Response
{
    public class EmployeeResponse
    {
        public string message { get; set; }
        public bool error { get; set; }
        public Employee employee { get; set; } = new Employee();
        public List<Employee> employees { get; set; } = new List<Employee>();

        public EmployeeResponse(List<Employee> employees)
        {
            this.employees = employees;
            message = "Employees gettings successfully";
            error = false;
        }

        public EmployeeResponse(string message, Employee employee)
        {
            this.employee = employee;
            this.message = message;
            error = false;
        }

        public EmployeeResponse(string message)
        {
            this.message = message;
            error = true;
        }
    }
        
}
