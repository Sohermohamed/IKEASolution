using IKEA.BLL.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Factories
{
    internal static class DepartmentFactory
    {
        public static DepartmentDto ToDepartmentDto(this Department department)
        {
            return new DepartmentDto()
            {
                DeptId = department.Id,
                Code = department.Code,
                Name = department.Name,
                Description = department.Description,
                DateOfCreation = department.CreatedOn.HasValue ? DateOnly.FromDateTime(department.CreatedOn.Value) : default
            };
        }

        public static DepartmentDetailsDto ToDepartmentDetailsDto(this Department department)
        {
            return new DepartmentDetailsDto()
            {
                Id = department.Id,
                Code = department.Code,
                Name = department.Name,
                Description = department.Description,
                CreatedBy = department.CreatedBy,
                ModifiedBy = department.ModifiedBy,
                CreatedOn = department.CreatedOn.HasValue ? DateOnly.FromDateTime(department.CreatedOn.Value) : default,
                ModifiedOn = department.ModifiedOn.HasValue ? DateOnly.FromDateTime(department.ModifiedOn.Value) : default
            };
        }

        public static Department ToEntity(this CreateDepartmentDto departmentDto)
        {
            return new Department()
            {
                Code = departmentDto.Code,
                Name = departmentDto.Name,
                Description = departmentDto.Description,
                //DateOnly to DateTime
                CreatedOn = departmentDto.DateOfCreation.ToDateTime(new TimeOnly(0, 0)) // DateOnly to DateTime
            };
        }

        public static Department ToEntity(this UpdatedDepartmentDto departmentDto)
        {
            return new Department()
            {
                Id = departmentDto.Id,
                Code = departmentDto.Code,
                Name = departmentDto.Name,
                Description = departmentDto.Description,
                CreatedOn = departmentDto.DateOfCreation.ToDateTime(new TimeOnly(0, 0)) // DateOnly to DateTime
            };
        }
    }
}
