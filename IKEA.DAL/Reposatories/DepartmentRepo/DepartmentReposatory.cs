using IKEA.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Reposatories.DepartmentRepo
{
   public class DepartmentReposatory(ApplicationDbContext _dbContext) : IdepartmentReposatory
    {     
        // GetAll
        public IEnumerable<Department> GetAll(bool withTracking = false)
        {
            if (withTracking)
                return _dbContext.Departments.ToList();
            else
                return _dbContext.Departments.AsNoTracking().ToList();

        }

        // GetById
        //public Department GetById(int id)
        //{
        //    var department = _dbContext.Departments.Find(id);
        //    return department;
        //}
        public Department GetById(int id) => _dbContext.Departments.Find(id);

        // Add
        public int Add(Department department)
        {
            _dbContext.Departments.Add(department); // Add Locally
            return _dbContext.SaveChanges();
            // _dbContext.Add(department);
            // _dbContext.Set<Department>().Add(department);
        }

        // Update
        public int Update(Department department)
        {
            _dbContext.Departments.Update(department);
            return _dbContext.SaveChanges(); // num of row affected
        }

        // Delete
        public int Remove(Department department)
        {
            _dbContext.Departments.Remove(department);
            return _dbContext.SaveChanges();
        }


    }
}
