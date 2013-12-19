using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SilkBazaar.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        // Do not add IDbSet<> for ApplicationUser! It's already contained by IdentityDbContext.
        public IDbSet<Product> Products { get; set; }
        public IDbSet<Transaction> Transactions { get; set; } 
    }
}