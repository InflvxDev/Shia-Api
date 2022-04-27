using Entity;

namespace BuinessLogic.AdopterServices.Response{
    public class AdopterResponse{
        public string message { get; set; }
        public bool error { get; set; }
        public Adopter adopter { get; set; } = new Adopter();
        public List<Adopter> adopters { get; set; } = new List<Adopter>();

        public AdopterResponse(List<Adopter> adopters)
        {
            this.adopters = adopters;
            this.message = "Adopters gettings successfully";
            this.error = false;
        }

        public AdopterResponse(string message, Adopter adopter)
        {
            this.adopter = adopter;
            this.message = message;
            this.error = false;
        }

        public AdopterResponse(string message)
        {
            this.message = message;
            this.error = true;
        }
    }
}