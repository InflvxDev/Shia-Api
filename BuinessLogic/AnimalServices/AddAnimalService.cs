using BuinessLogic.AnimalServices.Response;
using Data;
using Entity;

namespace BuinessLogic.AnimalServices{
    public class AddAnimalService{
        private readonly DataContext _dataContext;

        public AddAnimalService(DataContext dataContext){
            _dataContext = dataContext;
        }

        public AnimalResponse AddAnimal(Animal animal){
            try
            {
                var animalSearch = _dataContext.Animal.Find(animal.AnimalID);
                if (animalSearch != null){
                    return new AnimalResponse("Animal already exists");
                }
                animal.State = "Registered";
                _dataContext.Animal.Add(animal);
                _dataContext.SaveChanges();
                return new AnimalResponse("Animal added successfully",animal);
            }
            catch (System.Exception)
            {
                return new AnimalResponse("Error adding animal");
                throw;
            }
        }
    }
}