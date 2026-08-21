using HelpDeskSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskSystem.Controllers;

public class DepartmentsController : Controller
{
    private readonly ApplicationDbContext _context;

    public DepartmentsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var departments = await _context.Departments
            .Include(d => d.Employees)
            .ToListAsync();

        return View(departments);
    }
}