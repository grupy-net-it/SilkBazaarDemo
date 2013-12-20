using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SilkBazaar.Models
{
    public class ApplicationUser : IdentityUser
    {
        public decimal Money { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }

        public ApplicationUser Get(params object[] id)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Set<ApplicationUser>().Find(id);
            }
        }

        public IEnumerable<ApplicationUser> GetMany(Func<ApplicationUser, bool> constraint)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Set<ApplicationUser>().Where(constraint).ToList();
            }
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Set<ApplicationUser>().ToList();
            }
        }
    }
}