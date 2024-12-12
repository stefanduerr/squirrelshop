using System.ComponentModel.DataAnnotations;

namespace squirrels.Models
{
    public class User
    {
        [Key]                                        // Specifies that Id is the primary key
        public int Id { get; set; }

        [Required]                                   // Name cannot be null
        public string FirstName { get; set; } = string.Empty;
        
        [Required]                                   // Name cannot be null
        public string LastName { get; set; } = string.Empty;

        [EmailAddress]                                   // Name cannot be null
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string adress { get; set; } = string.Empty;

        public string postalCode { get; set; } = string.Empty;

        // Navigation Properties
        public ICollection<UserProduct> UserProducts { get; set; } = new List<UserProduct>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
