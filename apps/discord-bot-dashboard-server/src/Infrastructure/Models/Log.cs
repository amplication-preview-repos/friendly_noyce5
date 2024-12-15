using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DiscordBotDashboard.Core.Enums;

namespace DiscordBotDashboard.Infrastructure.Models;

[Table("Logs")]
public class LogDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? Message { get; set; }

    public DateTime? Timestamp { get; set; }

    public TypeFieldEnum? TypeField { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
