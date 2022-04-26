using BuinessLogic.AnimalServices.Response;
using Data;

namespace BuinessLogic.AnimalServices{
    public class GetOnlyAnimalService{
        private readonly DataContext _dataContext;

        public GetOnlyAnimalService(DataContext dataContext){
            _dataContext = dataContext;
        }

        public AnimalResponse GetOnlyAnimal(int animalID){
            try
            {
                var animal = _dataContext.Animals.Find(animalID);
                if (animal == null){
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