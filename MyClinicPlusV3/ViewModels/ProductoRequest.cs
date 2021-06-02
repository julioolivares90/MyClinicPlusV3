using MyClinicPlusV3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyClinicPlusV3.ViewModels
{
    public class ProductoRequest
    {
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Costo por Unidad")]
        public decimal CostoPorUnidad { get; set; }

        [Required]
        [Display(Name = "Costo publico")]
        public decimal CostoPublico { get; set; }

        [Required]
        public decimal Ganancia { get; set; }

        [Required]
        public int Cantidad { get; set; }

        public TipoProducto TipoProducto { get; set; }
    }
}
