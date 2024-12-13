using System.ComponentModel.DataAnnotations;

namespace squirrels.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string ProductType { get; set; } = string.Empty;

        public string? Size { get; set; }
        public string? Color { get; set; }

        public decimal Price { get; set; }
        public decimal? Discount { get; set; }

        public ICollection<CartProduct> CartProducts { get; set; } = new List<CartProduct>();
        public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
