using DiscordBotDashboard.Infrastructure;

namespace DiscordBotDashboard.APIs;

public class UsersService : UsersServiceBase
{
    public UsersService(DiscordBotDashboardDbContext context)
        : base(context) { }
}
