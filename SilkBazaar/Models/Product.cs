using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

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

        public static Product Get(params object[] id)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Products.Find(id);
            }
        }

        public static IEnumerable<Product> GetMany(Func<Product, bool> constraint)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Products.Where(constraint).ToList();
            }
        }

        public static IEnumerable<Product> GetAll()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Products.ToList();
            }
        }

        public void Add()
        {
            using (var context = new ApplicationDbContext())
            {
                context.Products.Add(this);
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
                context.Products.Remove(this);
                context.SaveChanges();
            }
        }
    }
}