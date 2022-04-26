using BuinessLogic.AnimalServices.Response;
using Data;

namespace BuinessLogic.AnimalServices{
    public class GetAllAnimalsService{
        private readonly DataContext _dataContext;

        public GetAllAnimalsService(DataContext dataContext){
            _dataContext = dataContext;
        }

        public AnimalResponse GetAllAnimals(){
            try
            {
                var animals = _dataContext.Animals.ToList();
                return new AnimalResponse(animals);
            }
            catch (System.Exception)
            {
                return new AnimalResponse("Error getting animals");
                throw;
            }
        }
    }
}