using Entity;

namespace BuinessLogic.EnterpriseServices.Response
{
    public class EnterpriseResponse
    {
        public string Message { get; set; }
        public bool Error { get; set; }
        public Enterprise Enterprise { get; set; } = new Enterprise();
        public List<Enterprise> Enterprises { get; set; } = new List<Enterprise>();

        public EnterpriseResponse(List<Enterprise> enterprises)
        {
            Enterprises = enterprises;
            Message = "Enterprises gettings successfully";
            Error = false;
        }

        public EnterpriseResponse(Enterprise enterprise)
        {
            Enterprise = enterprise;
            Message = "Enterprise added or updated successfully";
            Error = false;
        }

        public EnterpriseResponse(string message)
        {
            Message = message;
            Error = true;
        }
    }
}

