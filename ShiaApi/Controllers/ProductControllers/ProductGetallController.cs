using Microsoft.AspNetCore.Mvc;
using BuinessLogic.ProductServices;
using ShiaApi.Models;

namespace ShiaApi.Controllers.ProductControllers{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductGetallController : ControllerBase {

        private readonly GetAllProductsService _getAllProductsService;

        public ProductGetallController(DataContext context){
            _getAllProductsService = new GetAllProductsService(context);
        }

        [HttpGet]
        public ActionResult<ProductViewModel> Get(){
            var response = _getAllProductsService.GetAllProducts();

            if(response.error){
                ModelState.AddModelError("Get All Product", response.message);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            return Ok(response.products);
        }
    }
}