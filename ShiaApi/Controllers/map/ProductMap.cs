using Entity;
using ShiaApi.Models;

namespace ShiaApi.Controllers.map{
    public class ProductMap{
        public Product ProductMapper(ProductInputModel productInput){
            var product = new Product{

                ProductID = productInput.ProductID,
                Description = productInput.Description,
                Price = productInput.Price,
                Stock = productInput.Stock,
                State = productInput.State
            };
            return product;
        }
    }
}