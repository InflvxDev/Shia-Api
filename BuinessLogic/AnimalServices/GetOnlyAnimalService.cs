using BuinessLogic.AnimalServices.Response;
using Data;

namespace BuinessLogic.AnimalServices{
    public class GetOnlyAnimalService{
        private readonly DataContext _dataContext;

        public GetOnlyAnimalService(DataContext dataContext){
            _dataContext = dataContext;
        }

        public AnimalResponse GetOnlyAnimal(string animalID){
            try
            {
                var animal = _dataContext.Animal.Find(animalID);
                if (animal == null || animal.State == "Deleted"){
                    return new AnimalResponse("Animal not found");
                }
                return new AnimalResponse("Animal getting successfully",animal);
            }
            catch (System.Exception)
            {
                return new AnimalResponse("Error getting animal");
                throw;
            }
        }
    }
}