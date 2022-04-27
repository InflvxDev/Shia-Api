using BuinessLogic.AdopterServices.Response;
using Data;

namespace BuinessLogic.AdopterServices{
    public class DeleteAdopterService{
        private readonly DataContext _dataContext;

        public DeleteAdopterService(DataContext dataContext){
            _dataContext = dataContext;
        }

        public AdopterResponse DeleteAdopter(string identificationCard){
            try{
                var adopter = _dataContext.Adopters.Find(identificationCard);
                if(adopter == null){
                    return new AdopterResponse("Adopter not found");
                }

                adopter.State = "Deleted";
                _dataContext.Adopters.Update(adopter);
                _dataContext.SaveChanges();
                return new AdopterResponse("Adopter deleted successfully",adopter);

            }catch(System.Exception){
                return new AdopterResponse("Error deleting adopter");
                throw;
            }
        }
    }
}