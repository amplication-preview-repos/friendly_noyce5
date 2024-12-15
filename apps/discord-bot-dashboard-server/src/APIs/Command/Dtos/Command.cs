namespace DiscordBotDashboard.APIs.Dtos;

public class Command
{
    public DateTime CreatedAt { get; set; }

    public string Id { get; set; }

    public bool? IsActive { get; set; }

    public string? Name { get; set; }

    public DateTime UpdatedAt { get; set; }
}
