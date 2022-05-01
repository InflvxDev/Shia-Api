using Entity;
using ShiaApi.Models;

namespace ShiaApi.Controllers.map{
    public class AnimalMap{
        public Animal AnimalMapper(AnimalInputModel animalInput){
            var animal = new Animal{
                AnimalID = animalInput.AnimalID,
                Name = animalInput.Name,
                Description = animalInput.Description,
                Breed = animalInput.Breed,
                Age = animalInput.Age,
                Gender = animalInput.Gender,
                Type = animalInput.Type,
                State = animalInput.State
            };
            return animal;
        }
    }
}