using DiscordBotDashboard.Infrastructure;

namespace DiscordBotDashboard.APIs;

public class BotTokensService : BotTokensServiceBase
{
    public BotTokensService(DiscordBotDashboardDbContext context)
        : base(context) { }
}
