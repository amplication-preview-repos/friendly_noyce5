using DiscordBotDashboard.APIs.Dtos;
using DiscordBotDashboard.Infrastructure.Models;

namespace DiscordBotDashboard.APIs.Extensions;

public static class AnalyticsItemsExtensions
{
    public static Analytics ToDto(this AnalyticsDbModel model)
    {
        return new Analytics
        {
            ActiveUsers = model.ActiveUsers,
            BotUsageMetrics = model.BotUsageMetrics,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            MessageTrends = model.MessageTrends,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static AnalyticsDbModel ToModel(
        this AnalyticsUpdateInput updateDto,
        AnalyticsWhereUniqueInput uniqueId
    )
    {
        var analytics = new AnalyticsDbModel
        {
            Id = uniqueId.Id,
            ActiveUsers = updateDto.ActiveUsers,
            BotUsageMetrics = updateDto.BotUsageMetrics,
            MessageTrends = updateDto.MessageTrends
        };

        if (updateDto.CreatedAt != null)
        {
            analytics.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            analytics.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return analytics;
    }
}
