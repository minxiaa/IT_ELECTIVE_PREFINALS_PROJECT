using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpDeskSystem.Data;
using HelpDeskSystem.Models;

namespace HelpDeskSystem.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TicketsController(ApplicationDbContext context)
        {
            _context = context;
        }

       
        public async Task<IActionResult> Index(string search)
        {
            IQueryable<Ticket> ticketsQuery = _context.Tickets
                .Include(t => t.Customer)
                .Include(t => t.Category)
                .Include(t => t.Priority)
                .Include(t => t.Status);

            if (!string.IsNullOrEmpty(search))
            {
                ticketsQuery = ticketsQuery.Where(t =>
                    t.Subject.Contains(search) ||
                    t.Id.ToString().Contains(search));
            }

            var tickets = await ticketsQuery.ToListAsync();
            return View(tickets);
        }


        public async Task<IActionResult> Details(int id)
        {
            var ticketQuery = _context.Tickets
                .Include(t => t.Customer)
                .Include(t => t.Category)
                .Include(t => t.Priority)
                .Include(t => t.Status)
                .Include(t => t.Assignments).ThenInclude(a => a.Employee)
                .Include(t => t.Attachments)
                .Include(t => t.Comments)
                .Include(t => t.Tags).ThenInclude(tt => tt.Tag);

            var ticket = await ticketQuery.FirstOrDefaultAsync(t => t.Id == id);

            if (ticket == null) return NotFound();

            return View(ticket);
        }

  
        public async Task<IActionResult> CategoryHierarchy()
        {
            var categoriesQuery = _context.TicketCategories
                .Include(c => c.Children)
                .Include(c => c.Tickets).ThenInclude(t => t.Status)
                .Include(c => c.Tickets).ThenInclude(t => t.Priority);

            var categories = await categoriesQuery.ToListAsync();
            return View(categories);
        }

      
        public async Task<IActionResult> UnassignedTickets()
        {
            var unassignedQuery = _context.Tickets
                .Include(t => t.Category)
                .Include(t => t.Priority)
                .Include(t => t.Status)
                .Where(t => !t.Assignments.Any());

            var unassigned = await unassignedQuery.ToListAsync();
            return View(unassigned);
        }
    }
}
