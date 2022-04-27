using Entity;

namespace BuinessLogic.ProductServices.Response{
    public class ProductResponse{
        public string message { get; set; }
        public bool error { get; set; }
        public Product product { get; set; } = new Product();
        public List<Product> products { get; set; } = new List<Product>();

        public ProductResponse(List<Product> products)
        {
            this.products = products;
            this.message = "Products gettings successfully";
            this.error = false;
        }

        public ProductResponse(string message, Product product)
        {
            this.product = product;
            this.message = message;
            this.error = false;
        }

        public ProductResponse(string message)
        {
            this.message = message;
            this.error = true;
        }
    }
}