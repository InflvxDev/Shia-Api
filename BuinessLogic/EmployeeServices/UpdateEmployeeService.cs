using BuinessLogic.EmployeeServices.Response;
using Data;
using Entity;

namespace BuinessLogic.EmployeeService{
    public class UpdateEmployeeService{
        private readonly DataContext _context;

        public UpdateEmployeeService(DataContext context){
            _context = context;
        }

        public EmployeeResponse UpdateEmployee(Employee newEmployee){
            try
            {
                var oldEmployee = _context.Employee.Find(newEmployee.IdentificationCard);
                if(oldEmployee != null){

                    oldEmployee.Name = newEmployee.Name;
                    oldEmployee.LastName = newEmployee.LastName;
                    oldEmployee.Phone = newEmployee.Phone;
                    oldEmployee.Email = newEmployee.Email;
                    oldEmployee.IdentificationCard = newEmployee.IdentificationCard;
                    oldEmployee.Address = newEmployee.Address;
                    oldEmployee.Job = newEmployee.Job;

                    _context.Update(oldEmployee);
                    _context.SaveChanges();
                    return new EmployeeResponse("Employee updated successfully",oldEmployee);
                }
                else{
                    return new EmployeeResponse("Employee not found");
                }
            }
            catch (System.Exception)
            {
                return new EmployeeResponse("Error updating employee");
                throw;
            }
        }
    }
}