using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscordBotDashboard.Infrastructure.Models;

[Table("Analytics")]
public class AnalyticsDbModel
{
    [Range(-999999999, 999999999)]
    public int? ActiveUsers { get; set; }

    public string? BotUsageMetrics { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    public string? MessageTrends { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
