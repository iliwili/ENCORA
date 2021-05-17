using System;
using Microsoft.EntityFrameworkCore;

namespace les1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ShopContext())
            {
                db.Add(new Product { Naam = "Emmertje" });
                db.Add(new Product { Naam = "Spons" });
                db.Add(new Product { Naam = "Borstel" });
                db.SaveChanges();
            }
        }
    }
    public class ShopContext: DbContext 
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=database.db");
    }

    public class Product
    {
        public int ID { get; set; }
        public string Naam { get; set; }
        public float Prijs { get; set; }
    }
}
