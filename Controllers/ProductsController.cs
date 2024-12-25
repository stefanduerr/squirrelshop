using Microsoft.AspNetCore.Mvc;
using squirrels.Models;
using squirrels.Services;

namespace squirrels.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;
        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }
    }
}
