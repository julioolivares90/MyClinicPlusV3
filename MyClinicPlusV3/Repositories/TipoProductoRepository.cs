using MyClinicPlusV3.Data;
using MyClinicPlusV3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyClinicPlusV3.Repositories
{
    public class TipoProductoRepository : BaseRepository<TipoProducto> , ITipoProductoRepository
    {
        public TipoProductoRepository(VentasDbContext context) : base(context)
        {
                
        }
    }
}
