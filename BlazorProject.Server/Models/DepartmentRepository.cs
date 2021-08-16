using BlazorProject.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Server.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext db;

        public DepartmentRepository(AppDbContext appDbContext)
        {
            this.db = appDbContext;
        }
        public async Task<Department> GetDepartmentById(int departmentId) => await db.Department.FirstOrDefaultAsync(d => d.DepartmentId == departmentId);

        public async Task<IEnumerable<Department>> GetDepartments() => await db.Department.ToListAsync();
    }
}
