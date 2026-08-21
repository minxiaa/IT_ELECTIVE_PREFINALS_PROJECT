using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDeskSystem.Models;

[Table("TicketTags")]
public class TicketTag
{
    [Key]
    public int Id { get; set; }

    public int TicketId { get; set; }

    public int TagId { get; set; }

    [ForeignKey(nameof(TagId))]
    public Tag Tag { get; set; } = null!;

    [ForeignKey(nameof(TicketId))]
    public Ticket Ticket { get; set; } = null!;
}