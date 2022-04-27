using Entity;

namespace BuinessLogic.AnimalServices.Response{
    public class AnimalResponse{
        public string message { get; set; }
        public bool error { get; set; }
        public Animal animal { get; set; } = new Animal();
        public List<Animal> animals { get; set; } = new List<Animal>();

        public AnimalResponse(List<Animal> animals)
        {
            this.animals = animals;
            this.message = "Animals gettings successfully";
            this.error = false;
        }

        public AnimalResponse(string message, Animal animal)
        {
            this.animal = animal;
            this.message = message;
            this.error = false;
        }

        public AnimalResponse(string message)
        {
            this.message = message;
            this.error = true;
        }
    }
}