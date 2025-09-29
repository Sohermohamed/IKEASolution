namespace IKEA.PL.View_Models
{
    public class DepartmentEditViewModel
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateOnly CreatedOn { get; set; }

    }
}
