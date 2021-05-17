using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace les6
{
    class CafeContext : DbContext
    {
        public DbSet<Bestelling> Bestelling { get; set; }
        public DbSet<Drank> Drank { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=cafe.db");
    }
}
