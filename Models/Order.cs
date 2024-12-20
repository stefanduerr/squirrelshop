using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace squirrels.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [ForeignKey("User")]
        public int UserId { get; set; } // Foreign Key
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        // Navigation Properties
        public User User { get; set; } = new User();
        public ICollection<CartProduct> OrderProducts { get; set; } = new List<CartProduct>();

    }

    public enum OrderStatus
    {
        Pending,
        Completed,
        Cancelled
    }
}
