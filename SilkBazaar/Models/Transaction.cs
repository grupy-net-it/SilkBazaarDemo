using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

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

        public Transaction Get(params object[] id)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Set<Transaction>().Find(id);
            }
        }

        public IEnumerable<Transaction> GetMany(Func<Transaction, bool> constraint)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Set<Transaction>().Where(constraint).ToList();
            }
        }

        public IEnumerable<Transaction> GetAll()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Set<Transaction>().ToList();
            }
        }

        public void Add()
        {
            using (var context = new ApplicationDbContext())
            {
                this.Id = Guid.NewGuid();
                context.Set<Transaction>().Add(this);
                context.SaveChanges();
            }
        }

        public void Update()
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(this).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete()
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(this).State = EntityState.Deleted;
                context.Set<Transaction>().Remove(this);
                context.SaveChanges();
            }
        }
    }
}