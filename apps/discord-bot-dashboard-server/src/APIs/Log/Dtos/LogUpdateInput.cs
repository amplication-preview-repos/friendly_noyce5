using DiscordBotDashboard.Core.Enums;

namespace DiscordBotDashboard.APIs.Dtos;

public class LogUpdateInput
{
    public DateTime? CreatedAt { get; set; }

    public string? Id { get; set; }

    public string? Message { get; set; }

    public DateTime? Timestamp { get; set; }

    public TypeFieldEnum? TypeField { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
