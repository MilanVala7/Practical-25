namespace Practical25.Domain.Entities;

public class Employee : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public decimal Salary { get; set; }
    public Department DepartmentId { get; set; }
    public string EmailId { get; set; } = string.Empty;
    public DateTime JoiningDate { get; set; }
    public bool Status { get; set; } = true;
    public string? Notes { get; set; }
}
