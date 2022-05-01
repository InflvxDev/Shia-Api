using BuinessLogic.AdopterServices.Response;
using Data;
using Entity;

namespace BuinessLogic.AdopterServices{
    public class AddAdopterService{
        private readonly DataContext _dataContext;

        public AddAdopterService(DataContext dataContext){
            _dataContext = dataContext;
        }

        public AdopterResponse AddAdopter(Adopter adopter){
            try{
                var adopterSearch = _dataContext.Adopter.Find(adopter.IdentificationCard);
                if(adopterSearch != null){
                    if (adopterSearch.State == "Deleted"){

                        adopterSearch.Name = adopter.Name;
                        adopterSearch.LastName = adopter.LastName;
                        adopterSearch.Phone = adopter.Phone;
                        adopterSearch.Email = adopter.Email;
                        adopterSearch.Address = adopter.Address;
                        adopterSearch.State = "Registered";
                        _dataContext.Update(adopterSearch);
                        _dataContext.SaveChanges();

                        return new AdopterResponse("Adopter added successfully", adopterSearch);
                    }
                    return new AdopterResponse("Adopter already exists");
                }

                adopter.State = "Registered";
                _dataContext.Adopter.Add(adopter);
                _dataContext.SaveChanges();
                return new AdopterResponse("Adopter added uccessfully",adopter);

            }catch(System.Exception){
                return new AdopterResponse("Error adding adopter");
                throw;
            }
        }
        
    }
}