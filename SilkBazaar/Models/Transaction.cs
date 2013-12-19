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

        public Transaction Add(Transaction entity)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Set<Transaction>().Add(entity);
                context.SaveChanges();
            }

            return entity;
        }

        public Transaction Update(Transaction entity)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }

            return entity;
        }

        public Transaction Delete(Transaction entity)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Set<Transaction>().Remove(entity);
                context.SaveChanges();
            }

            return entity;
        }
    }
}