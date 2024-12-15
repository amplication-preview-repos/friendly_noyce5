using DiscordBotDashboard.APIs;
using DiscordBotDashboard.APIs.Common;
using DiscordBotDashboard.APIs.Dtos;
using DiscordBotDashboard.APIs.Errors;
using DiscordBotDashboard.APIs.Extensions;
using DiscordBotDashboard.Infrastructure;
using DiscordBotDashboard.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscordBotDashboard.APIs;

public abstract class AnalyticsItemsServiceBase : IAnalyticsItemsService
{
    protected readonly DiscordBotDashboardDbContext _context;

    public AnalyticsItemsServiceBase(DiscordBotDashboardDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Analytics
    /// </summary>
    public async Task<Analytics> CreateAnalytics(AnalyticsCreateInput createDto)
    {
        var analytics = new AnalyticsDbModel
        {
            ActiveUsers = createDto.ActiveUsers,
            BotUsageMetrics = createDto.BotUsageMetrics,
            CreatedAt = createDto.CreatedAt,
            MessageTrends = createDto.MessageTrends,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            analytics.Id = createDto.Id;
        }

        _context.AnalyticsItems.Add(analytics);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<AnalyticsDbModel>(analytics.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Analytics
    /// </summary>
    public async Task DeleteAnalytics(AnalyticsWhereUniqueInput uniqueId)
    {
        var analytics = await _context.AnalyticsItems.FindAsync(uniqueId.Id);
        if (analytics == null)
        {
            throw new NotFoundException();
        }

        _context.AnalyticsItems.Remove(analytics);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many AnalyticsItems
    /// </summary>
    public async Task<List<Analytics>> AnalyticsItems(AnalyticsFindManyArgs findManyArgs)
    {
        var analyticsItems = await _context
            .AnalyticsItems.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return analyticsItems.ConvertAll(analytics => analytics.ToDto());
    }

    /// <summary>
    /// Meta data about Analytics records
    /// </summary>
    public async Task<MetadataDto> AnalyticsItemsMeta(AnalyticsFindManyArgs findManyArgs)
    {
        var count = await _context.AnalyticsItems.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Analytics
    /// </summary>
    public async Task<Analytics> Analytics(AnalyticsWhereUniqueInput uniqueId)
    {
        var analyticsItems = await this.AnalyticsItems(
            new AnalyticsFindManyArgs { Where = new AnalyticsWhereInput { Id = uniqueId.Id } }
        );
        var analytics = analyticsItems.FirstOrDefault();
        if (analytics == null)
        {
            throw new NotFoundException();
        }

        return analytics;
    }

    /// <summary>
    /// Update one Analytics
    /// </summary>
    public async Task UpdateAnalytics(
        AnalyticsWhereUniqueInput uniqueId,
        AnalyticsUpdateInput updateDto
    )
    {
        var analytics = updateDto.ToModel(uniqueId);

        _context.Entry(analytics).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.AnalyticsItems.Any(e => e.Id == analytics.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
