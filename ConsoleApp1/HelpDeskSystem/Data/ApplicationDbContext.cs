using Microsoft.EntityFrameworkCore;
using HelpDeskSystem.Models;

namespace HelpDeskSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

       
        public DbSet<Ticket> Tickets { get; set; } = null!;
        public DbSet<TicketAssignment> TicketAssignments { get; set; } = null!;
        public DbSet<TicketAttachment> TicketAttachments { get; set; } = null!;
        public DbSet<TicketCategory> TicketCategories { get; set; } = null!;
        public DbSet<TicketComment> TicketComments { get; set; } = null!;

      
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Team> Teams { get; set; } = null!;
        public DbSet<TeamMember> TeamMembers { get; set; } = null!;
        public DbSet<TicketPriority> TicketPriorities { get; set; } = null!;
        public DbSet<TicketStatus> TicketStatuses { get; set; } = null!;

       
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;
        public DbSet<TicketTag> TicketTags { get; set; } = null!;
    }
}
