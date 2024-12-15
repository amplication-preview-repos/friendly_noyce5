using DiscordBotDashboard.Infrastructure;

namespace DiscordBotDashboard.APIs;

public class LogsService : LogsServiceBase
{
    public LogsService(DiscordBotDashboardDbContext context)
        : base(context) { }
}
