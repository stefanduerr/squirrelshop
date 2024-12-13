using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace squirrels.Models;
public class Review
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Product")]
    public int ProductId { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }

    [Required]
    public int Rating { get; set; }

    public string Comment { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Product Product { get; set; }
    public User User { get; set; }
}