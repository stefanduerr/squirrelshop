using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace squirrels.Models;
public class Order
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }

    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public OrderStatus Status { get; set; } = OrderStatus.Pending;


    public User User { get; set; }
    public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
}

public enum OrderStatus
{
    Pending,
    Completed,
    Cancelled
}
