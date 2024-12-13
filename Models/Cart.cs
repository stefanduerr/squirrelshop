using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace squirrels.Models;

public class Cart
{
    [Key]
    public int Id {get; set;}

    [ForeignKey("User")]
    public int UserId {get; set;}

    public User User {get; set;} = new User();
    public ICollection<CartProduct> CartProducts {get; set;} = new List<CartProduct>();
    
}