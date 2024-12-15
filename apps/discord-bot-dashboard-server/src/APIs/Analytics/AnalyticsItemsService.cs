using DiscordBotDashboard.Infrastructure;

namespace DiscordBotDashboard.APIs;

public class AnalyticsItemsService : AnalyticsItemsServiceBase
{
    public AnalyticsItemsService(DiscordBotDashboardDbContext context)
        : base(context) { }
}
