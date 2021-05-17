using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace les2
{
    class ShopContext : DbContext
    {
        public DbSet<Client> Clients{ get; set; }
        public DbSet <Order> Orders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=todo.db");
    }
}
