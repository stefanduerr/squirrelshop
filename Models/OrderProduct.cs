using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace squirrels.Models;
public class OrderProduct
{
    [Key]
    public int Id { get; set; } // Primary Key

    [ForeignKey("Order")]
    public int OrderId { get; set; } // Foreign Key

    [ForeignKey("Product")]
    public int ProductId { get; set; } // Foreign Key

    public int Quantity { get; set; } // Quantity of the product in the order

    // Navigation Properties
    public Order Order { get; set; }
    public Product Product { get; set; }
}