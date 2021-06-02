using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyClinicPlusV3.Models
{
    public class DetalleVenta  : BaseEntity
    {
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public decimal  PrecioVenta { get; set; }

        public int VentaId { get; set; }
        public Venta Venta { get; set; }

        public int ProductoId { get; set; }
        public Producto Producto { get; set; }


    }
}
