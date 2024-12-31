using squirrels.Models;
using Squirrels.Data;
using Microsoft.EntityFrameworkCore;

namespace squirrels.Services;

public class ProductService
{
    private readonly AppDbContext _appDbContext;

    public ProductService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<List<Product>> GetAllProducts() 
    { 
        return await _appDbContext.Products.ToListAsync(); 
    }

    public async Task<Product> AddProduct(Product newProduct)
    {

        // Repository pattern would prevent future service changes if db access is changed
        _appDbContext.Products.Add(newProduct);
        await _appDbContext.SaveChangesAsync();
        return newProduct;
    }

    //TODO: Write AddProductToCart method here
    //public async Task<CartProduct> AddCartProduct(int userId, int productId, int quantity)
    //{
    //    // Retrieve the existing User and Product from the database
    //    var user = await _appDbContext.Users.FindAsync(userId);
    //    if (user == null)
    //    {
    //        throw new ArgumentException($"User with ID {userId} not found.");
    //    }

    //    var product = await _appDbContext.Products.FindAsync(productId);
    //    if (product == null)
    //    {
    //        throw new ArgumentException($"Product with ID {productId} not found.");
    //    }

    //    // Create a new CartProduct with references to the User and Product
    //    var cartProduct = new CartProduct
    //    {
    //        User = user,
    //        Product = product,
    //        Quantity = quantity
    //    };

    //    // Add the CartProduct to the database
    //    _appDbContext.CartProducts.Add(cartProduct);
    //    await _appDbContext.SaveChangesAsync();

    //    return cartProduct;
    //}

}
