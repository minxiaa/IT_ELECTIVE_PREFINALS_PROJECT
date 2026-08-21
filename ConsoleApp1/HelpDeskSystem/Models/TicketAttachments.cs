using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HelpDeskSystem;

[Table("TicketAttachments")]
public class TicketAttachment
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int TicketId { get; set; }

    [Required]
    public string FileName { get; set; } = string.Empty;

    [Required]
    public string FilePath { get; set; } = string.Empty;

    [Required]
    public DateTime UploadedAt { get; set; }

    [ForeignKey(nameof(TicketId))]
    public Ticket? Ticket { get; set; }
}