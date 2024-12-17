using EmployeesApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmployeesApplication.DAL
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext()
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Deportment>().ToTable("Deportment");
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Deportment> Deportments { get; set; }
    }
}