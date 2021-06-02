using Microsoft.EntityFrameworkCore;
using MyClinicPlusV3.Data;
using MyClinicPlusV3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyClinicPlusV3.Repositories
{
    public class ProductoRepository : BaseRepository<Producto>, IProductoRepository
    {
        public ProductoRepository(VentasDbContext context) : base(context)
        {

        }

        public async Task<List<Producto>> GetProductosWithTipoAsync()
        {
            var productos = await _context.Productos.Include(p => p.TipoProducto).ToListAsync();
            return productos;
        }

        public async Task<Producto> GetProductoByIdWithTipoAsync(int id)
        {
            var producto = await _context.Productos.Where(x => x.Id == id).FirstOrDefaultAsync();
            return producto;
        }

        public async Task<Producto> FindMedicamentoByName(string name)
        {
            var producto = await _context.Productos.Where(x => x.Nombre == name).FirstOrDefaultAsync();
            return producto;
        }

        public async  Task<Producto> UpdateStockProducto(int idProducto, int cantidad)
        {
            var oldProducto = await GetByIDAsync(idProducto);

            oldProducto.Cantidad = oldProducto.Cantidad - cantidad;
            var result = await UpdateAsync(oldProducto);
            return result;

        }

        public async Task<Producto> AddProductsToStock(int idProducto, int cantidad)
        {
            var oldProducto = await GetByIDAsync(idProducto);
            oldProducto.Cantidad = oldProducto.Cantidad + cantidad;
            var result = await UpdateAsync(oldProducto);
            return result;
        }
    }
}
