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
                var productSearch = _dataContext.Product.Find(product.ProductID);
                if(productSearch != null){
                    if(productSearch.State == "Deleted"){

                        productSearch.Description = product.Description;
                        productSearch.Price = product.Price;
                        productSearch.Stock = product.Stock;
                        productSearch.State = "Registered";
                        _dataContext.Update(productSearch);
                        _dataContext.SaveChanges();

                        return new ProductResponse("Product add successfully", productSearch);
                    }
                    return new ProductResponse("Product already exists");
                }

                product.State = "Registered";
                _dataContext.Product.Add(product);
                _dataContext.SaveChanges();
                return new ProductResponse("Product added successfully",product);

            }catch(System.Exception ex){
                return new ProductResponse("Error adding product " + ex.Message);
                throw;
            }
        }
    }
}