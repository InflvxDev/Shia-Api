using Microsoft.AspNetCore.Mvc;
using BuinessLogic.ProductServices;
using ShiaApi.Models;

namespace ShiaApi.Controllers.ProductControllers{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductGetOnlyController: ControllerBase {
        private readonly GetOnlyProductService _getOnlyProductService;

        public ProductGetOnlyController(DataContext context){
            _getOnlyProductService = new GetOnlyProductService(context);
        }

        [HttpGet("{productID}")]
        public ActionResult<ProductViewModel> Get(string productID){
            var response = _getOnlyProductService.GetOnlyProduct(productID);

            if(response.error){
                ModelState.AddModelError("Get Only Product", response.message);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            return Ok(response.product);
        }
    }
}