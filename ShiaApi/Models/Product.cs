using Entity;

namespace ShiaApi.Models{
    public class ProductInputModel{
        public string ProductID { get; set; }
        public string Description { get; set; } 
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string State { get; set; }
    }

    public class ProductViewModel : ProductInputModel{
        public ProductViewModel(){

        }

        public ProductViewModel(Product product){
            ProductID = product.ProductID;
            Description = product.Description;
            Price = product.Price;
            Stock = product.Stock;
            State = product.State;
        }
    }
}