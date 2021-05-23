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
            
            builder.Entity<TipoProducto>().ToTable(nameof(TipoProducto)).HasMany(c => c.Productos);
            builder.Entity<Producto>().ToTable(nameof(Producto)).HasOne(c => c.TipoProducto);
        }


    }
}
