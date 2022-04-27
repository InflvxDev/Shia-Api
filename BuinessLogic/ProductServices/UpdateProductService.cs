using BuinessLogic.ProductServices.Response;
using Data;
using Entity;

namespace BuinessLogic.ProductServices{
    public class UpdateProductService{
        private readonly DataContext _dataContext;

        public UpdateProductService(DataContext dataContext){
            _dataContext = dataContext;
        }

        public ProductResponse UpdateProduct(Product newProduct){
            try{
                var oldProduct = _dataContext.Products.Find(newProduct.ProductID);
                if(oldProduct != null){

                    oldProduct.Description = newProduct.Description;
                    oldProduct.Price = newProduct.Price;
                    oldProduct.Stock = newProduct.Stock;
                    oldProduct.ProductID = newProduct.ProductID;
                    oldProduct.State = newProduct.State;

                    _dataContext.Update(oldProduct);
                    _dataContext.SaveChanges();

                    return new ProductResponse("Product updated successfully", oldProduct);

                }
                else{
                    return new ProductResponse("Product not found");
                }
            }
            catch (System.Exception)
            {
                return new ProductResponse("Error updating product");
                throw;
            }
        }
    }
}