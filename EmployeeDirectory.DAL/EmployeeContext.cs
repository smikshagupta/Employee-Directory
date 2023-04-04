using EmployeeDirectory.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.DAL
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext(DbContextOptions options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department>Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Office> Offices { get; set; }
    }
}
