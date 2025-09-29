using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Services
{
   public interface IdepartmentServices
    {
        int AddDepartment(CreateDepartmentDto departmentDto);
        bool DeleteDepartment(int id);
        IEnumerable<DepartmentDto> GetAllDepartments();
        DepartmentDetailsDto? GetDepartmentById(int id);
        void Test(int id);
        int UpdateDepartment(UpdatedDepartmentDto updatedDepartmentDto);
    }
}
