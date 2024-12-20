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
        //  If ProductType is always expected to be non-null, initializing it with string.Empty communicates that intent clearly
        public string? Size { get; set; }

        public string? Color { get; set; }

        public long Price { get; set; }

        public long? Discount { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        // Navigation Properties
        public ICollection<UserProduct> UserProducts { get; set; } = new List<UserProduct>();
        public ICollection<CartProduct> OrderProducts { get; set; } = new List<CartProduct>();
    }
}
