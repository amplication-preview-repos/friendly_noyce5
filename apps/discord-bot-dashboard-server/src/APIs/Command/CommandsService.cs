using DiscordBotDashboard.Infrastructure;

namespace DiscordBotDashboard.APIs;

public class CommandsService : CommandsServiceBase
{
    public CommandsService(DiscordBotDashboardDbContext context)
        : base(context) { }
}
