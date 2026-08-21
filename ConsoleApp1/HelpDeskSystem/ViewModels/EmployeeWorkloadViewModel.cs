namespace Helpdesksystem.Models.ViewModels;

public class EmployeeWorkloadViewModel
{
    public string EmployeeName { get; set; } = string.Empty;
    public string DepartmentName { get; set; } = string.Empty;
    public int AssignedTicketCount { get; set; }
}