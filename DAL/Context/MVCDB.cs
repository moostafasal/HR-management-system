using DAL.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class MVCDB:IdentityDbContext<ApplicationUser>
    {
        public MVCDB(DbContextOptions<MVCDB> options) : base(options)
        {

                
        }  
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        
        //  =>  optionsBuilder.UseSqlServer("server=.;Databaes=MVCDB;trusted_connction=true;");

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        //public DbSet<IdentityUser> users { get; set; }

    }
}
