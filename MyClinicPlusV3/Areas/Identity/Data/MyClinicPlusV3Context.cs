using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyClinicPlusV3.Models;

namespace MyClinicPlusV3.Data
{
    public class MyClinicPlusV3Context : IdentityDbContext<User>
    {
        public MyClinicPlusV3Context(DbContextOptions<MyClinicPlusV3Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
        }
    }
}
