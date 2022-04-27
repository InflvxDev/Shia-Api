using BuinessLogic.AnimalServices.Response;
using Data;

namespace BuinessLogic.AnimalServices{
    public class DeleteAnimalService {
        private readonly DataContext _dataContext;

        public DeleteAnimalService(DataContext dataContext) {
            _dataContext = dataContext;
        }

        public AnimalResponse DeleteAnimal(string animalID){
            try {
                var animal = _dataContext.Animals.Find(animalID);
                if (animal == null) {
                    return new AnimalResponse("Animal not found");
                }
                animal.State = "Deleted";
                _dataContext.Animals.Update(animal);
                _dataContext.SaveChanges();
                return new AnimalResponse("Animal deleted successfully", animal);
            } catch (System.Exception) {
                return new AnimalResponse("Error deleting animal");
                throw;
            }
        }
    }
}