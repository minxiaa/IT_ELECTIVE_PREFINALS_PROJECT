using HelpDeskSystem.Models;
using System.ComponentModel.DataAnnotations;


namespace HelpDeskSystem.Models
{
    public class TicketStatus
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int IsClosed { get; set; } = 0;
    }
}