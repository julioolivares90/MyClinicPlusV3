using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyClinicPlusV3.Controllers
{
    public class VenderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
