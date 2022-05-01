using Entity;
using ShiaApi.Models;

namespace ShiaApi.Controllers.map{
    public class AdopterMap{
        public Adopter AdopterMapper(AdopterInputModel adopterInput){
            var adopter = new Adopter{
                IdentificationCard = adopterInput.IdentificationCard,
                Name = adopterInput.Name,
                LastName = adopterInput.LastName,
                Email = adopterInput.Email,
                Phone = adopterInput.Phone,
                Address = adopterInput.Address,
                State = adopterInput.State
            };
            return adopter;
        }
    }
}