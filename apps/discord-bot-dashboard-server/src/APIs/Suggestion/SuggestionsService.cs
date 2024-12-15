using DiscordBotDashboard.Infrastructure;

namespace DiscordBotDashboard.APIs;

public class SuggestionsService : SuggestionsServiceBase
{
    public SuggestionsService(DiscordBotDashboardDbContext context)
        : base(context) { }
}
