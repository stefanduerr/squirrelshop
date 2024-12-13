using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace squirrels.Models;

public class CartProduct
{
    [Key]
    public int Id {get; set;}

    [ForeignKey("Cart")]
    public int CartId {get; set;}

    [ForeignKey("Product")]
    public int ProductId {get; set;}

    public int Quantity {get; set;}

    public Cart Cart {get; set;}
    public Product Product {get; set;}
}