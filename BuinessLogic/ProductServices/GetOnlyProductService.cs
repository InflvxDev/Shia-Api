using BuinessLogic.ProductServices.Response;
using Data;

namespace BuinessLogic.ProductServices{
    public class GetOnlyProductService{
        private readonly DataContext _dataContext;

        public GetOnlyProductService(DataContext dataContext){
            _dataContext = dataContext;
        }

        public ProductResponse GetOnlyProduct(string productID){
            try{
                var product = _dataContext.Product.Find(productID);
                if(product == null || product.State == "Deleted"){
                    return new ProductResponse("Product not found");
                }
                return new ProductResponse("Product getting successfully",product);
            }catch(System.Exception){
                return new ProductResponse("Error getting product");
                throw;
            }
        }
    }
}