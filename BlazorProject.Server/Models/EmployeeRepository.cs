using BlazorProject.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Server.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext db;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            this.db = appDbContext;
        }


        public async Task<Employee> GetEmployeeByEmail(string email) => await db.Employee.Include(d => d.Department).FirstOrDefaultAsync(e => e.Email == email);
        public async Task<Employee> GetEmployeeById(int EmpployeeId) => await db.Employee.Include(d => d.Department).FirstOrDefaultAsync(e => e.EmployeeId == EmpployeeId);
        public async Task<IEnumerable<Employee>> GetEmployees() => await db.Employee.ToListAsync();




        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            Employee result = await db.Employee.FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);
           
            if (result != null)
            { 
                db.Employee.Update(employee);
                await db.SaveChangesAsync();

                return employee;
            }
            return null;
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            EntityEntry<Employee> result = await db.Employee.AddAsync(employee);
            await db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteEmployee(int EmpployeeId)
        {
            Employee result = await db.Employee.FirstOrDefaultAsync(e => e.EmployeeId == EmpployeeId);

            if (result != null)
            {
                db.Employee.Remove(result);
                await db.SaveChangesAsync();
            }
            else
            {

            }
        }


        public async Task<IEnumerable<Employee>> Search(string name, Gender? gender)
        {
            IQueryable<Employee> query = db.Employee;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.FirstName.Contains(name) || e.LastName.Contains(name));
            }

            if (gender != null)
            {
                query = query.Where(e => e.Gender == gender);
            }

            return await query.ToListAsync();
        }


    }
}
