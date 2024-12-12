using System.ComponentModel.DataAnnotations;

namespace squirrels.Models
{
    public class Product
    {
        [Key]                                        // Specifies that Id is the primary key
        public int Id { get; set; }

        [Required]                                   // Name cannot be null
        public string Name { get; set; } = string.Empty;
        
        [Required]                                   // Name cannot be null
        public string ProductType { get; set; } = string.Empty;
                                   // Name cannot be null
        public string? Size { get; set; }

        public string? Color { get; set; }

        public long Price { get; set; }

        public long? Discount { get; set; }

        // Navigation Properties
        public ICollection<UserProduct> UserProducts { get; set; } = new List<UserProduct>();
        public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
