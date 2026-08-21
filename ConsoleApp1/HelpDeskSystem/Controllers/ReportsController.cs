using HelpDeskSystem.Data;
using HelpDeskSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskSystem.Controllers;

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
                EmployeeName = e.FullName,
                DepartmentName = e.Department.Name,
                UnresolvedTicketCount = 0 
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
                EmployeeCount = d.Employees.Count,
                UnresolvedTicketCount = 0 
            })
            .ToListAsync();

        return View(workload);
    }
}