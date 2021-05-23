using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyClinicPlusV3.Models
{
    public class TipoProducto : BaseEntity
    {

       

        [Required]
        public string Tipo { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public ICollection<Producto> Productos { get; set; }
    }
}
