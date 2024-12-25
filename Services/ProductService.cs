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

}
