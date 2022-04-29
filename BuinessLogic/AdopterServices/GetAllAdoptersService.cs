using BuinessLogic.AdopterServices.Response;
using Data;

namespace BuinessLogic.AdopterServices{
    public class GetAllAdoptersService{
        private readonly DataContext _dataContext;

        public GetAllAdoptersService(DataContext dataContext){
            _dataContext = dataContext;
        }

        public AdopterResponse GetAllAdopters(){
            try{
                var adopters = _dataContext.Adopter.Where(a => a.State == "Registered").ToList();
                return new AdopterResponse(adopters);
            }catch(System.Exception){
                return new AdopterResponse("Error getting adopters");
                throw;
            }
        }
    }
}