using Entity;

namespace ShiaApi.Models{
    public class EmployeeInputModel{
        public string IdentificationCard { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
         public string Job { get; set; }
        public string State { get; set; }
    }

    public  class EmployeeViewModel : EmployeeInputModel{
        public EmployeeViewModel(){

        }

        public EmployeeViewModel(Employee employee){
            IdentificationCard = employee.IdentificationCard;
            Name = employee.Name;
            LastName = employee.LastName;
            Email = employee.Email;
            Phone = employee.Phone;
            Address = employee.Address;
            Job = employee.Job;
            State = employee.State;
        }
    }
}