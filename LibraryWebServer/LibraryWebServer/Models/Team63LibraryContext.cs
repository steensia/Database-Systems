using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LibraryWebServer.Models
{
    public partial class Team63LibraryContext : DbContext
    {
        public Team63LibraryContext()
        {
        }

        public Team63LibraryContext(DbContextOptions<Team63LibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CheckedOut> CheckedOut { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Patrons> Patrons { get; set; }
        public virtual DbSet<Phones> Phones { get; set; }
        public virtual DbSet<Titles> Titles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=atr.eng.utah.edu;User Id=u1031024;Password=aero123;Database=Team63Library");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CheckedOut>(entity =>
            {
                entity.HasKey(e => e.Serial)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.CardNum)
                    .HasName("CardNum");

                entity.HasOne(d => d.CardNumNavigation)
                    .WithMany(p => p.CheckedOut)
                    .HasForeignKey(d => d.CardNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CheckedOut_ibfk_1");

                entity.HasOne(d => d.SerialNavigation)
                    .WithOne(p => p.CheckedOut)
                    .HasForeignKey<CheckedOut>(d => d.Serial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CheckedOut_ibfk_2");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => e.Serial)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.Isbn)
                    .HasName("ISBN");

                entity.Property(e => e.Isbn)
                    .IsRequired()
                    .HasColumnName("ISBN")
                    .HasColumnType("char(14)");

                entity.HasOne(d => d.IsbnNavigation)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.Isbn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Inventory_ibfk_1");
            });

            modelBuilder.Entity<Patrons>(entity =>
            {
                entity.HasKey(e => e.CardNum)
                    .HasName("PRIMARY");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Phones>(entity =>
            {
                entity.HasKey(e => new { e.CardNum, e.Phone })
                    .HasName("PRIMARY");

                entity.Property(e => e.Phone).HasColumnType("char(8)");

                entity.HasOne(d => d.CardNumNavigation)
                    .WithMany(p => p.Phones)
                    .HasForeignKey(d => d.CardNum)
                    .HasConstraintName("Phones_ibfk_1");
            });

            modelBuilder.Entity<Titles>(entity =>
            {
                entity.HasKey(e => e.Isbn)
                    .HasName("PRIMARY");

                entity.Property(e => e.Isbn)
                    .HasColumnName("ISBN")
                    .HasColumnType("char(14)");

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(100)");
            });
        }
    }
}
