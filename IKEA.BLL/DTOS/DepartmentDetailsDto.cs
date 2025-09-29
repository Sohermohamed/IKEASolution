using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.DTOS
{
    public class DepartmentDetailsDto
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; } // UserId
        public DateOnly? CreatedOn { get; set; } // the date time of creating the record
        public int ModifiedBy { get; set; } //UserId
        public DateOnly? ModifiedOn { get; set; } // the date time of modifing the record
        public bool IsDeleted { get; set; } // Soft Delete
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }


        // Constructor Mapping
        //public DepartmentDetailsDto(Department department)
        //{
        //    Id = department.Id;
        //    Code = department.Code;
        //    Name = department.Name;
        //    Description = department.Description;
        //    CreatedBy = department.CreatedBy;
        //    IsDeleted = department.IsDeleted;
        //    ModifiedBy = department.ModifiedBy;
        //    CreatedOn = department.CreatedOn.HasValue ? DateOnly.FromDateTime(department.CreatedOn.Value) : default;
        //    ModifiedOn = department.ModifiedOn.HasValue ? DateOnly.FromDateTime(department.ModifiedOn.Value) : default;
        //}
    }
}
