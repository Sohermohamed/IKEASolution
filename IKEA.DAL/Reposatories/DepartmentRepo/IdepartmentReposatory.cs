using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Reposatories.DepartmentRepo
{
   public interface IdepartmentReposatory
    {
        int Add(Department department);
        IEnumerable<Department> GetAll(bool withTracking = false);
        Department GetById(int id);
        int Remove(Department department);
        int Update(Department department);

    }
}
