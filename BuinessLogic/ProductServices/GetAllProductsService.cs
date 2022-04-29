using BuinessLogic.ProductServices.Response;
using Data;

namespace BuinessLogic.ProductServices{
    public class GetAllProductsService{
        private readonly DataContext _dataContext;

        public GetAllProductsService(DataContext dataContext){
            _dataContext = dataContext;
        }

        public ProductResponse GetAllProducts(){
            try{
                var products = _dataContext.Product.Where(p => p.State == "Registered").ToList();
                return new ProductResponse(products);
            }catch(System.Exception){
                return new ProductResponse("Error getting products");
                throw;
            }
        }
    }
}