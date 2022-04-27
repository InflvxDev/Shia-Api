using BuinessLogic.AnimalServices.Response;
using Data;
using Entity;

namespace BuinessLogic.AnimalServices{
    public class UpdateAnimalService{
        private readonly DataContext _dataContext;

        public UpdateAnimalService(DataContext dataContext){
            _dataContext = dataContext;
        }

        public AnimalResponse UpdateAnimal(Animal newAnimal){
            try
            {
                var oldAnimal = _dataContext.Animals.Find(newAnimal.AnimalID);
                if(oldAnimal != null){

                    oldAnimal.Name = newAnimal.Name;
                    oldAnimal.Age = newAnimal.Age;
                    oldAnimal.Type = newAnimal.Type;
                    oldAnimal.Breed = newAnimal.Breed;
                    oldAnimal.Description = newAnimal.Description;
                    oldAnimal.AnimalID = newAnimal.AnimalID;
                    oldAnimal.Gender = newAnimal.Gender;

                    _dataContext.Update(oldAnimal);
                    _dataContext.SaveChanges();

                    return new AnimalResponse("Animal updated successfully", oldAnimal);
    
                }
                else{
                    return new AnimalResponse("Animal not found");
                }
            }
            catch (System.Exception)
            {
                return new AnimalResponse("Error updating animal");
                throw;
            }
        }
    }
}