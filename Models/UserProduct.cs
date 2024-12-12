using System.ComponentModel.DataAnnotations;

namespace squirrels.Models
{
    public class UserProduct
    {
        [Key]
        public int UserProductId { get; set; } // Primary Key
        public int UserId { get; set; } // Foreign Key
        public int ProductId { get; set; } // Foreign Key

        // Navigation Properties
        public User User { get; set; } = new User();
        public Product Product { get; set; } = new Product();
    }
}
