using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace les8
{
    class GameContext : DbContext
    {
        public DbSet<HighScore> HighScore { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=game.db");
    }
}
