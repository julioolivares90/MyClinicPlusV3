using MyClinicPlusV3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyClinicPlusV3.Repositories
{
    public interface IProductoRepository : IBaseRepository<Producto>
    {
        Task<List<Producto>> GetProductosWithTipoAsync();
        Task<Producto> GetProductoByIdWithTipoAsync(int id);
        Task<Producto> FindMedicamentoByName(string name);
        Task<Producto> UpdateStockProducto(int idProducto, int cantidad);
        Task<Producto> AddProductsToStock(int idProducto, int cantidad);
    }
}
