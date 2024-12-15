using DiscordBotDashboard.APIs;

namespace DiscordBotDashboard;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IAnalyticsService, AnalyticsService>();
        services.AddScoped<IBotTokensService, BotTokensService>();
        services.AddScoped<ICommandsService, CommandsService>();
        services.AddScoped<ILogsService, LogsService>();
        services.AddScoped<ISuggestionsService, SuggestionsService>();
        services.AddScoped<IUsersService, UsersService>();
    }
}
