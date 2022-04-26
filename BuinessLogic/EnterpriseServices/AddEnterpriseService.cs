using BuinessLogic.EnterpriseServices.Response;
using Data;
using Entity;

namespace BuinessLogic.EnterpriseServices
{
    public class AddEnterpriseService
    {
        private readonly DataContext _context;

        public AddEnterpriseService(DataContext context)
        {
            _context = context;
        }

        public EnterpriseResponse AddEnterPrise(Enterprise enterprise){
            try
            {
                var enterpriseSearch = _context.Enterprises.Find(enterprise.Nit);
                if (enterpriseSearch != null)
                {
                    return new EnterpriseResponse("Enterprise already exists");
                }
                _context.Enterprises.Add(enterprise);
                _context.SaveChanges();
                return new EnterpriseResponse(enterprise);
            }
            catch (System.Exception exception)
            {
                return new EnterpriseResponse($"Error adding enterprise: {exception.Message}");
                throw;
            }
        }      
    }
}
