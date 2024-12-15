using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DiscordBotDashboard.Core.Enums;

namespace DiscordBotDashboard.Infrastructure.Models;

[Table("Suggestions")]
public class SuggestionDbModel
{
    [StringLength(1000)]
    public string? AdminFeedback { get; set; }

    [StringLength(1000)]
    public string? BriefDescription { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    public StatusEnum? Status { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    [StringLength(1000)]
    public string? Username { get; set; }
}
