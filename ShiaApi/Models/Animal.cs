using Entity;

namespace ShiaApi.Models{
    public class AnimalInputModel{
       public string AnimalID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public string Type { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }       
        public string Gender {get; set;}        
        public string State { get; set; }
    }

    public class AnimalViewModel : AnimalInputModel{
        public AnimalViewModel(){

        }

        public AnimalViewModel(Animal animal){
            AnimalID = animal.AnimalID;
            Name = animal.Name;
            Description = animal.Description;
            Type = animal.Type;
            Breed = animal.Breed;
            Age = animal.Age;
            Gender = animal.Gender;
            State = animal.State;
         }
    }
}