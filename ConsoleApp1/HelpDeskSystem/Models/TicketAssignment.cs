using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourProject.Models
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
        public DateTime AssignedAt { get; set; }

        public DateTime? UnassignedAt { get; set; }

        [Required]
        public bool IsPrimary { get; set; }


        [ForeignKey(nameof(TicketId))]
        public Ticket? Ticket { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public Employee? Employee { get; set; }
    }
}