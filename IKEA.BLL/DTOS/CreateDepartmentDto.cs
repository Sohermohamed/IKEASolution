using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.DTOS
{
    public class CreateDepartmentDto
    {
        [Required]  // The Default Error Message will be appeared
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Code is required !!")]
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateOnly DateOfCreation { get; set; }
    }
}
