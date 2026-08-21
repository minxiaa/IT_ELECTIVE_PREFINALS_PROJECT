using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDeskSystem.Models
{
    [Table("TicketAssignments")]
    [PrimaryKey(nameof(TicketId), nameof(EmployeeId))]
    public class TicketAssignment
    {


        [Required]
        public int TicketId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public string AssignedAt { get; set; } = string.Empty;

        public string? UnassignedAt { get; set; }

        [Required]
        public bool IsPrimary { get; set; }


        [ForeignKey(nameof(TicketId))]
        public Ticket Ticket { get; set; } = null!;

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; } = null!;


    }
}

