using BuinessLogic.EnterpriseServices.Response;
using Data;
using Entity;

namespace BuinessLogic.EnterpriseServices
{
    public class UpdateEnterpriseService {
        private readonly DataContext _context;

        public UpdateEnterpriseService(DataContext context) {
            _context = context;
        }

        public EnterpriseResponse UpdateEnterprise(Enterprise newEnterprise){
            try
            {
                var oldEnterprise = _context.Enterprises.Find(newEnterprise.Nit);

                if (oldEnterprise != null){
                    
                    oldEnterprise.Name = newEnterprise.Name;
                    oldEnterprise.Address = newEnterprise.Address;
                    oldEnterprise.Phone = newEnterprise.Phone;
                    oldEnterprise.Email = newEnterprise.Email;
                    oldEnterprise.Nit = newEnterprise.Nit;

                    _context.Update(oldEnterprise);
                    _context.SaveChanges();
                    return new EnterpriseResponse(oldEnterprise);
                }
                else{
                    return new EnterpriseResponse("Enterprise not found");
                }
                
            }
            catch (System.Exception exception)
            {
                return new EnterpriseResponse($"Error updating enterprise: {exception.Message}");
                throw;
            }
        }
    }
}