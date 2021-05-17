using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace les7
{
    public partial class warehouseContext : DbContext
    {
        public warehouseContext()
        {
        }

        public warehouseContext(DbContextOptions<warehouseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pieces> Pieces { get; set; }
        public virtual DbSet<Providers> Providers { get; set; }
        public virtual DbSet<Provides> Provides { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;database=warehouse;user=root;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pieces>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PRIMARY");

                entity.ToTable("pieces");

                entity.Property(e => e.Code).HasColumnType("int(11)");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Providers>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PRIMARY");

                entity.ToTable("providers");

                entity.Property(e => e.Code).HasMaxLength(255);

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Provides>(entity =>
            {
                entity.HasKey(e => new { e.Piece, e.Provider })
                    .HasName("PRIMARY");

                entity.ToTable("provides");

                entity.HasIndex(e => e.Provider)
                    .HasName("Provider");

                entity.Property(e => e.Piece).HasColumnType("int(11)");

                entity.Property(e => e.Provider).HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnType("int(11)");

                entity.HasOne(d => d.PieceNavigation)
                    .WithMany(p => p.Provides)
                    .HasForeignKey(d => d.Piece)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("provides_ibfk_1");

                entity.HasOne(d => d.ProviderNavigation)
                    .WithMany(p => p.Provides)
                    .HasForeignKey(d => d.Provider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("provides_ibfk_2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
