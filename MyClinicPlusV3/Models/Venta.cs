using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyClinicPlusV3.Models
{
    public class Venta : BaseEntity
    {
       

        public DateTime FechaVenta { get; set; }

        public decimal Monto { get; set; }

        public int descuento { get; set; }

        public ICollection<DetalleVenta> DetalleVenta { get; set; }

        public string UserId { get; set; }
        public User Usuario { get; set; }
    }
}
