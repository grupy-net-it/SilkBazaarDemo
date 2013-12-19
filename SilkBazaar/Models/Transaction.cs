using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SilkBazaar.Models
{
    public class Transaction
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }

        [ForeignKey("Product")]
        public Guid ProductId { get; set; }

        public int Count { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public Product Product { get; set; }
    }
}