using BuinessLogic.EnterpriseServices.Response;
using Data;

namespace BuinessLogic.EnterpriseServices
{
    public class GetAllEnterprisesService
    {
        private readonly DataContext _context;

        public GetAllEnterprisesService(DataContext context)
        {
            _context = context;
        }

        public EnterpriseResponse GetAllEnterprises()
        {
            try
            {
                var enterprises = _context.Enterprises.ToList();
                return new EnterpriseResponse(enterprises);
            }
            catch (System.Exception exception)
            {
                return new EnterpriseResponse($"Error getting enterprises {exception.Message}");
                throw;
            }
        }
    }
}