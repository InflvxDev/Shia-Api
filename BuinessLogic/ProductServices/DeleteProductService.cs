using BuinessLogic.ProductServices.Response;
using Data;

namespace BuinessLogic.ProductServices{
    public class DeleteProductService{
        private readonly DataContext _dataContext;

        public DeleteProductService(DataContext dataContext){
            _dataContext = dataContext;
        }

        public ProductResponse DeleteProduct(string productID){
            try{
                var product = _dataContext.Product.Find(productID);
                if(product == null){
                    return new ProductResponse("Product not found");
                }

                product.State = "Deleted";
                _dataContext.Product.Update(product);
                _dataContext.SaveChanges();
                return new ProductResponse("Product deleted successfully",product);

            }catch(System.Exception){
                return new ProductResponse("Error deleting product");
                throw;
            }
        }
    }
}