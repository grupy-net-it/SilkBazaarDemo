using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SilkBazaar.Models
{
    public class ApplicationUser : IdentityUser
    {
        public decimal Money { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}