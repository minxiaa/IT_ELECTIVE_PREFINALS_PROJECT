using Helpdesksystem.Models.ViewModels;
using HelpDeskSystem.Data;
using HelpDeskSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Helpdesksystem.Controllers
{
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
                    AssignedTicketCount = e.TicketAssignments.Count 
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
                    TicketCount = d.Employees
                        .SelectMany(emp => emp.TicketAssignments) 
                        .Count()
                })
                .ToListAsync();

            return View(workload);
        }

        public async Task<IActionResult> MultipleAssigneeTickets()
        {
            var tickets = await _context.Tickets
                .Include(t => t.TicketAssignees)
                    .ThenInclude(a => a.Employee)
                .Where(t => t.TicketAssignees.Count > 1) 
                .ToListAsync();

            return View(tickets);
        }

        public async Task<IActionResult> PrimaryAssignee()
        {
            var tickets = await _context.Tickets
                .Include(t => t.TicketAssignees)
                    .ThenInclude(a => a.Employee)
                .Where(t => t.TicketAssignees.Any(a => a.IsPrimary)) // <-- check IsPrimary
                .ToListAsync();

            return View(tickets);
        }
    }
}
