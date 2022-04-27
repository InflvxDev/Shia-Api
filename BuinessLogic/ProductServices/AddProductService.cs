using BuinessLogic.ProductServices.Response;
using Data;
using Entity;

namespace BuinessLogic.ProductServices{
    public class AddProductService{
        private readonly DataContext _dataContext;

        public AddProductService(DataContext dataContext){
            _dataContext = dataContext;
        }

        public ProductResponse AddProduct(Product product){
            try{
                var productSearch = _dataContext.Products.Find(product.ProductID);
                if(productSearch != null){
                    return new ProductResponse("Product already exists");
                }

                product.State = "Registered";
                _dataContext.Products.Add(product);
                _dataContext.SaveChanges();
                return new ProductResponse("Product added successfully",product);

            }catch(System.Exception){
                return new ProductResponse("Error adding product");
                throw;
            }
        }
    }
}