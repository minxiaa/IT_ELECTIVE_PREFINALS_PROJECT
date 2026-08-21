using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDeskSystem.Models;

[Table("Employees")]
public class Employee
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;

    // Kina-calculate lang sa C# at hindi na hinahanap sa Database
    [NotMapped]
    public string FullName => $"{FirstName} {LastName}";

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