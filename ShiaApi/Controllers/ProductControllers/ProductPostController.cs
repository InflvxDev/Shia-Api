using Microsoft.AspNetCore.Mvc;
using BuinessLogic.ProductServices;
using ShiaApi.Models;
using Entity;
using ShiaApi.Controllers.map;

namespace ShiaApi.Controllers.ProductControllers{
   
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPostController : ControllerBase{

        private readonly AddProductService _addProductService;

        public ProductPostController(DataContext context){
            _addProductService = new AddProductService(context);
        }


        [HttpPost]
        public ActionResult<ProductViewModel> Post(ProductInputModel productInputModel){
            Product product = new ProductMap().ProductMapper(productInputModel);
            var response = _addProductService.AddProduct(product);

            if(response.error){
                ModelState.AddModelError("Add Product", response.message);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            return Ok(response.message);
        }
    }

}