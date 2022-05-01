using BuinessLogic.AdopterServices.Response;
using Data;

namespace BuinessLogic.AdopterServices{
    public class GetOnlyAdopterService{
        private readonly DataContext _dataContext;

        public GetOnlyAdopterService(DataContext dataContext){
            _dataContext = dataContext;
        }

        public AdopterResponse GetOnlyAdopter(string identificationCard){
            try{
                var adopter = _dataContext.Adopter.Find(identificationCard);
                if(adopter == null || adopter.State == "Deleted"){
                    return new AdopterResponse("Adopter not found");
                }
                return new AdopterResponse("Adopter getting successfully",adopter);
            }catch(System.Exception){
                return new AdopterResponse("Error getting adopter");
                throw;
            }
        }
    }
}