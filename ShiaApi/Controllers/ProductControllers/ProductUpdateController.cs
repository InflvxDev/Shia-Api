using Microsoft.AspNetCore.Mvc;
using BuinessLogic.ProductServices;
using ShiaApi.Models;
using ShiaApi.Controllers.map;
using Entity;

namespace ShiaApi.Controllers.ProductControllers{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductUpdateController: ControllerBase{
        private readonly UpdateProductService _updateProductService;

        public ProductUpdateController(DataContext context){
            _updateProductService = new UpdateProductService(context);
        }

        [HttpPut]
        public ActionResult<ProductViewModel> Put(ProductInputModel productInput){
            Product product = new ProductMap().ProductMapper(productInput);
            var response = _updateProductService.UpdateProduct(product);
            if(response.error){
                ModelState.AddModelError("Update Product", response.message);
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