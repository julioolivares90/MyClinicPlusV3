using MyClinicPlusV3.Data;
using MyClinicPlusV3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyClinicPlusV3.Repositories
{
    public class VentaRepository : BaseRepository<Venta> , IVentaRepository
    {
        public VentaRepository(VentasDbContext context ): base(context)
        {
                
        }
    }
}
