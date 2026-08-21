using System.ComponentModel.DataAnnotations.Schema;

namespace Helpdesksystem.Models;

[Table("TicketTags")]
public class TicketTag
{
    public int TicketId { get; set; }

    public int TagId { get; set; }

    [ForeignKey(nameof(TagId))]
    public Tag Tag { get; set; } = null!;
}