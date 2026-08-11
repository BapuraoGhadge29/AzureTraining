using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;

namespace ProductAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductAPIController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = new[]
            {
                new { Id = 1, Name = "Laptop", Price = 55000 },
                new { Id = 2, Name = "Mobile", Price = 25000 },
                new { Id = 3, Name = "Headphones", Price = 3000 }
            };

            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = new
            {
                Id = id,
                Name = "Sample Product",
                Price = 1000
            };

            return Ok(product);
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            return CreatedAtAction(nameof(GetProduct),
                new { id = product.Id },
                product);
        }
    }
}