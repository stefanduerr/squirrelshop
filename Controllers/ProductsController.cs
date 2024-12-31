using Microsoft.AspNetCore.Authorization;
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

        // Route: GET /api/products/
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [Authorize]
        [HttpPost("add")]
        public async Task<ActionResult<Product>> AddProduct([FromBody] Product newProduct)
        {
            var addedProduct = await _productService.AddProduct(newProduct);
            return Ok(addedProduct);
        }

        [Authorize]
        [HttpPost("addToCart")]
        public async Task<ActionResult<CartProduct>> AddProductToCart([FromBody] CartProduct newCartProduct)
        {
            //var addedCartProduct = await _productService.AddProductToCart(newCartProduct);
            //return Ok(addedCartProduct);
            throw new NotImplementedException();
        }

    }
}
