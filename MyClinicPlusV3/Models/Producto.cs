using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyClinicPlusV3.Models
{
    public class Producto : BaseEntity
    {
        
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [Display(Name ="Costo por Unidad")]
        public decimal CostoPorUnidad { get; set; }

        [Required]
        [Display(Name ="Costo publico")]
        public decimal CostoPublico { get; set; }

        [Required]
        public decimal Ganancia { get; set; }

        [Required]
        public int Cantidad { get; set; }

        public int TipoProductoId { get; set; }
        public TipoProducto TipoProducto { get; set; }

       
        public ICollection<DetalleVenta> DetalleVenta { get; set; }
    }
}
