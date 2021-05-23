using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyClinicPlusV3.Models
{
    public class User : IdentityUser
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public ICollection<Venta> MyProperty { get; set; }
    }
}
