using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CA_Employee_Entity.Models
{
    public class CompanyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = (localdb)\ProjectModels; Initial Catalog = Company; Integrated Security = True;");
        }

        public DbSet<Employee> Employees { get; set; }  //if we don't specify this migration file will be blank & tables will be not created
        public DbSet<Department> Departments { get; set; }
    }
}
 