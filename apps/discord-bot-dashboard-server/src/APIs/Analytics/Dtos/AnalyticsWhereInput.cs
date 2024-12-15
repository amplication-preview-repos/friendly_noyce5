namespace DiscordBotDashboard.APIs.Dtos;

public class AnalyticsWhereInput
{
    public int? ActiveUsers { get; set; }

    public string? BotUsageMetrics { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Id { get; set; }

    public string? MessageTrends { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
