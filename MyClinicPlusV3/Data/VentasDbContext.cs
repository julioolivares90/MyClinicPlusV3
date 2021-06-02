using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyClinicPlusV3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyClinicPlusV3.Data
{
    public class VentasDbContext : IdentityDbContext<User>
    {
        public VentasDbContext(DbContextOptions<VentasDbContext> options) : base(options)
        {
                
        }

        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetalleVentas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<TipoProducto> TipoProductos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<TipoProducto>()
                .HasMany(c => c.Productos).WithOne(c=>c.TipoProducto).OnDelete(DeleteBehavior.Cascade).HasForeignKey(c=>c.TipoProductoId);

            builder.Entity<Producto>()
                .HasOne(c => c.TipoProducto).WithMany(c=>c.Productos).HasForeignKey(c=>c.TipoProductoId).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<DetalleVenta>().HasOne(c => c.Producto).WithMany(c => c.DetalleVenta).HasForeignKey(c=>c.VentaId).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Venta>().HasMany(c => c.DetalleVenta).WithOne(c=>c.Venta).HasForeignKey(c=>c.VentaId).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Venta>().HasOne(c => c.Usuario).WithMany(c => c.Ventas).HasForeignKey(c=>c.UserId).OnDelete(DeleteBehavior.Cascade);


        }


    }
}
