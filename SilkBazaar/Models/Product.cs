using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SilkBazaar.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}