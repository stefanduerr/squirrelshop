using System.ComponentModel.DataAnnotations;

namespace squirrels.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;

    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string PostalCode { get; set; } = string.Empty;


    public Cart Cart { get; set; }
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}

