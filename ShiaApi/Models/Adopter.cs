using Entity;

namespace ShiaApi.Models{

    public class AdopterInputModel{
        public string IdentificationCard { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
    }

    public class AdopterViewModel : AdopterInputModel{
        public AdopterViewModel(){

        }

        public AdopterViewModel(Adopter adopter){
            IdentificationCard = adopter.IdentificationCard;
            Name = adopter.Name;
            LastName = adopter.LastName;
            Email = adopter.Email;
            Phone = adopter.Phone;
            Address = adopter.Address;
            State = adopter.State;
        }
    }
}