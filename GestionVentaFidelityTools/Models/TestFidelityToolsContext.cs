using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GestionVentaFidelityTools.Models
{
    public partial class TestFidelityToolsContext : DbContext
    {
        public TestFidelityToolsContext()
        {
        }

        public TestFidelityToolsContext(DbContextOptions<TestFidelityToolsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DetallesVentas> DetallesVentas { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<TiposProductos> TiposProductos { get; set; }
        public virtual DbSet<Ventas> Ventas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=TestFidelityTools;Trusted_Connection=True;");
               
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetallesVentas>(entity =>
            {
                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.DetallesVentas)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetallesVentas_Productos");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithMany(p => p.DetallesVentas)
                    .HasForeignKey(d => d.IdVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetallesVentas_Ventas");
            });

            modelBuilder.Entity<Productos>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(11, 2)");

                entity.HasOne(d => d.IdTipoProductoNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdTipoProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Productos_TiposProductos");
            });

            modelBuilder.Entity<TiposProductos>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ventas>(entity =>
            {
                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Importe).HasColumnType("decimal(11, 2)");
            });
        }
    }
}
