using Helpdesksystem.Models.ViewModels;
using HelpDeskSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Helpdesksystem.Controllers;

public class ReportsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ReportsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> EmployeeWorkload()
    {
        var workload = await _context.Employees
            .Where(e => e.IsActive)
            .Select(e => new EmployeeWorkloadViewModel
            {
                EmployeeName = e.FirstName + " " + e.LastName,
                DepartmentName = e.Department != null ? e.Department.Name : "N/A",
                AssignedTicketCount = 0
            })
            .ToListAsync();

        return View(workload);
    }

    public async Task<IActionResult> DepartmentWorkload()
    {
        var workload = await _context.Departments
            .Select(d => new DepartmentWorkloadViewModel
            {
                DepartmentName = d.Name,
                TicketCount = d.Employees.Count
            })
            .ToListAsync();

        return View(workload);
    }
}