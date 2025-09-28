using IKEA.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Reposatories.DepartmentRepo
{
   public class DepartmentReposatory
    {
        private ApplicationDbContext _context;
        public DepartmentReposatory(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Department> GetALLDepartments()
        {
            var Departments = _context.Departments.ToList();
            return Departments;
        }
        public Department GetDepartmentById(int id)
        {
            using (var context = new Contexts.ApplicationDbContext())
            {
                return context.Departments.FirstOrDefault(d => d.Id == id && !d.IsDeleted);
            }
        }
        public void AddDepartment(Department department)
        {
            using (var context = new Contexts.ApplicationDbContext())
            {
                context.Departments.Add(department);
                context.SaveChanges();
            }
        }
        public void UpdateDepartment(Department department)
        {
            using (var context = new Contexts.ApplicationDbContext())
            {
                context.Departments.Update(department);
                context.SaveChanges();
            }
        }
        public void DeleteDepartment(int id)
        {
            using (var context = new Contexts.ApplicationDbContext())
            {
                var department = context.Departments.FirstOrDefault(d => d.Id == id);
                if (department != null)
                {
                    department.IsDeleted = true;
                    context.SaveChanges();
                }
            }



        }
}
