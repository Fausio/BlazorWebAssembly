using BlazorProject.Shared; 
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Server.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // seed departmanet table data
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentId = 1, DepartmentName = "IT" });
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentId = 2, DepartmentName = "HR" });
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentId = 3, DepartmentName = "Payroll" });
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentId = 4, DepartmentName = "Admin" });

            //seed employee datble data
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                FirstName = "Fáusio",
                LastName = "Matsinhe",
                Email = "Fausio@mail.com",
                DateOfBirth = DateTime.Now.AddYears(-20),
                DepartmentId = 1,
                Gender = Gender.Male,
                photopath ="images/fausio.jpg"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 2,
                FirstName = "John",
                LastName = "Hastings",
                Email = "edv@mail.com",
                DateOfBirth = DateTime.Now.AddYears(-30),
                DepartmentId = 2,
                Gender = Gender.Male,
                photopath = "images/John.jpg"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 3,
                FirstName = "Fernando",
                LastName = "Carlos",
                Email = "Fernandoo@live.com",
                DateOfBirth = DateTime.Now.AddYears(-20),
                DepartmentId = 2,
                Gender = Gender.Other,
                photopath = "images/Fernando.jpg"
            });
        }

        DbSet<Department> Department { get; set; }
        DbSet<Employee> employee { get; set; }


    }
}
