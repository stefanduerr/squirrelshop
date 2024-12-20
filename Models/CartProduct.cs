﻿using System.ComponentModel.DataAnnotations;

namespace squirrels.Models
{
    public class CartProduct
    {
        [Key]
        public int Id { get; set; } // Primary Key
        public int OrderId { get; set; } // Foreign Key
        public int ProductId { get; set; } // Foreign Key
        public int Quantity { get; set; }

        // Navigation Properties
        public User User { get; set; } = new User();
        public Product Product { get; set; } = new Product();
    }
}
