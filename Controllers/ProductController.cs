using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoredProcedure.Models;
using StoredProcedure.Services;

namespace StoredProcedure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            _productService.AddProduct(product.Name, product.Price);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product product)
        {
            _productService.UpdateProduct(id, product.Name, product.Price);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _productService.GetAllProducts();

            return Ok(products); 
        }
       

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productService.GetProductById(id);

            if (product == null)
            {
                return NotFound(); // Return a 404 Not Found response if the product with the specified ID is not found.
            }

            return Ok(product); // Return the product if found (HTTP 200 OK).
        }
    }
}






    