using BuinessLogic.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace ShiaApi.Controllers.ProductControllers{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductDeleteController : ControllerBase {
        private readonly DeleteProductService _deleteProductService;

        public ProductDeleteController(DataContext context){
            _deleteProductService = new DeleteProductService(context);
        }

        [HttpDelete("{productID}")]
        public ActionResult<string> Delete(string productID){
            var response = _deleteProductService.DeleteProduct(productID);
            if(response.error){
                ModelState.AddModelError("Delete Product", response.message);
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