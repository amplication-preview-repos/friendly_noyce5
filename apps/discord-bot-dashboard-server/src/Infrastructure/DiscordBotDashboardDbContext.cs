using DiscordBotDashboard.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscordBotDashboard.Infrastructure;

public class DiscordBotDashboardDbContext : DbContext
{
    public DiscordBotDashboardDbContext(DbContextOptions<DiscordBotDashboardDbContext> options)
        : base(options) { }

    public DbSet<CommandDbModel> Commands { get; set; }

    public DbSet<BotTokenDbModel> BotTokens { get; set; }

    public DbSet<LogDbModel> Logs { get; set; }

    public DbSet<AnalyticsDbModel> AnalyticsItems { get; set; }

    public DbSet<SuggestionDbModel> Suggestions { get; set; }

    public DbSet<UserDbModel> Users { get; set; }
}
