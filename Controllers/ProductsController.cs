using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using squirrels.DTOs;
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
        public async Task<ActionResult<CartProduct>> AddCartProduct([FromBody] CartProductDTO dto)
        {
            var addedCartProduct = await _productService.AddCartProduct(dto.UserId, dto.ProductId, dto.Quantity);

            var response = new CartProductResponseDTO
            {
                Id = addedCartProduct.Id,
                UserId = addedCartProduct.User.Id,
                ProductId = addedCartProduct.Product.Id,
                Quantity = addedCartProduct.Quantity
            };

            return Ok(response);
        }

    }
}
