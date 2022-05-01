using BuinessLogic.AdopterServices.Response;
using Data;
using Entity;

namespace BuinessLogic.AdopterServices{
    public class UpdateAdopterService{
        private readonly DataContext _dataContext;

        public UpdateAdopterService(DataContext dataContext){
            _dataContext = dataContext;
        }

        public AdopterResponse UpdateAdopter(Adopter newAdopter){
            try{
                var oldAdopter = _dataContext.Adopter.Find(newAdopter.IdentificationCard);
                if (oldAdopter != null && oldAdopter.State == "Registered"){

                    oldAdopter.Name = newAdopter.Name;
                    oldAdopter.LastName = newAdopter.LastName;
                    oldAdopter.IdentificationCard = newAdopter.IdentificationCard;
                    oldAdopter.Email = newAdopter.Email;
                    oldAdopter.Phone = newAdopter.Phone;
                    oldAdopter.Address = newAdopter.Address;
                    oldAdopter.State = newAdopter.State;

                    _dataContext.Adopter.Update(oldAdopter);
                    _dataContext.SaveChanges();
                    return new AdopterResponse("Adopter updated successfully",oldAdopter);
                }
                else{
                    return new AdopterResponse("Adopter not found");
                }
            }catch(System.Exception){
                return new AdopterResponse("Error updating newAdopter");
                throw;
            }
        }
    }
}