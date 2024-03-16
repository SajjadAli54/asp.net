using CentosCrafts.Models;
using CentosCrafts.Services;
using Microsoft.AspNetCore.Mvc;

namespace CentosCrafts.Controllers
{
    [Route("/products")]
    [ApiController]
    public class ProductControllers : ControllerBase
    {
        public JsonFileProductService ProductService { get; }

        public ProductControllers(JsonFileProductService productService)
        {
            this.ProductService = productService;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        }

        // [HttpPatch]
        [Route("Rate")]
        [HttpGet]
        public ActionResult Get(
            [FromQuery] string productId,
            [FromQuery] int rating)
        {
            ProductService.AddRating(productId, rating);
            return Ok();
        }
    }
}

// http://localhost:5028/products/Rate?productId=jenlooper-cactus&rating=5