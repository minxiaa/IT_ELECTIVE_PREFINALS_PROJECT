using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helpdesksystem.Models;

[Table("Employees")]
public class Employee
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string FullName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    public string? JobTitle { get; set; }

    [Required]
    public int DepartmentId { get; set; }

    public bool IsActive { get; set; } = true;

    [ForeignKey(nameof(DepartmentId))]
    public Department Department { get; set; } = null!;
}