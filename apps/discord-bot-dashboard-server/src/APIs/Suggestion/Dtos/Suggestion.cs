using DiscordBotDashboard.Core.Enums;

namespace DiscordBotDashboard.APIs.Dtos;

public class Suggestion
{
    public string? AdminFeedback { get; set; }

    public string? BriefDescription { get; set; }

    public DateTime CreatedAt { get; set; }

    public string Id { get; set; }

    public StatusEnum? Status { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? Username { get; set; }
}
