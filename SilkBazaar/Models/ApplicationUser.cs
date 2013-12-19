using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public ApplicationUser Add(ApplicationUser entity)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Set<ApplicationUser>().Add(entity);
                context.SaveChanges();
            }

            return entity;
        }

        public ApplicationUser Update(ApplicationUser entity)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }

            return entity;
        }

        public ApplicationUser Delete(ApplicationUser entity)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Set<ApplicationUser>().Remove(entity);
                context.SaveChanges();
            }

            return entity;
        }
    }
}